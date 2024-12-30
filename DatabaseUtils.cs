using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using ADOX;
using Property = bobFinal.PropertiesFolder.Property;

namespace bobFinal
{
    public static class DatabaseUtils
    {
        // note:  in Interop.ADOX, I have been unable to change the Change Embed Interop Types to False
        private const string Database = "bobFinalDatabase.mdb";
        private const string ConnectionString = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source=" + Database + ";";

        public static void InitializeDatabase()
        {
            DeleteDatabase();
            CreateDatabase();
            CreateTables();
        }

        private static void CreateDatabase()
        {
            try
            {
                // Check if the database exists
                if (File.Exists(Database)) return;

                // Create a catalog object
                Catalog cat = new Catalog();

                // Create the database
                cat.Create(ConnectionString);
            }
            catch (Exception ex)
            {
                Program.ShowAutoClosingMessageBox($@"Error creating database: {ex.Message}", @"Database Creation Error", 2000);
            }
        }

        public static void DeleteDatabase()
        {
            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bobFinalDatabase.mdb");

            try
            {
                // delete the database file
                File.Delete(databasePath);
            }
            catch (Exception ex)
            {
                Program.ShowAutoClosingMessageBox($@"Error deleting database: {ex.Message}", @"Error", 2000);
            }
        }

        public static DataTable LoadLessonStatus()
        {
            const string query = "SELECT LessonId, Completed, Title, Question FROM lessonsTable";
            return ExecuteQuery(query);
        }

        private static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();
            ExecuteDatabaseOperation(query, parameters, cmd =>
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dataTable);
            });
            return dataTable;
        }

        private static void ExecuteSqlNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            ExecuteDatabaseOperation(query, parameters, cmd => { cmd.ExecuteNonQuery(); });
        }


        public static DataTable LoadDatabaseData(string whichTable)
        {
            string query = $"SELECT * FROM {whichTable}"; // SQL query to fetch all records from the specified table

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error loading data: {ex.Message}", @"Error", 2000);
                }
            }

            return null;
        }

        private static void CreateTables()
        {
            const string createPropertiesTable = @"
            CREATE TABLE Properties (
                Id INTEGER PRIMARY KEY,
                [Property Type] TEXT NOT NULL,
                Coordinate TEXT NOT NULL,
                Active YESNO DEFAULT TRUE,
                Connected YESNO DEFAULT FALSE,
                [Gold Cost] INTEGER NOT NULL,
                [Lumber Cost] INTEGER NOT NULL,
                [Daily Gold Gain] INTEGER NOT NULL,
                [Daily Lumber Gain] INTEGER NOT NULL,
                [Daily Diamond Gain] INTEGER NOT NULL,
                [Total Gold Gain] INTEGER NOT NULL,
                [Total Lumber Gain] INTEGER NOT NULL
            );";
            ExecuteSqlNonQuery(createPropertiesTable);

            const string createIncomeHistoryTable = @"
            CREATE TABLE incomeHistoryTable (
                [Date] DATETIME NOT NULL PRIMARY KEY,
                Gold INTEGER NOT NULL,
                Lumber INTEGER NOT NULL,
                Diamonds INTEGER NOT NULL,
                [Number Of Properties] INTEGER NOT NULL
            );";

            ExecuteSqlNonQuery(createIncomeHistoryTable);

            const string createLessonsTable = @"
            CREATE TABLE lessonsTable (
                LessonId AUTOINCREMENT PRIMARY KEY,
                Topic TEXT NOT NULL,
                Title TEXT NOT NULL,
                Question TEXT NOT NULL,
                CorrectAnswerIndex INTEGER NOT NULL,
                Reward INTEGER NOT NULL,
                ChoiceOne TEXT NOT NULL,
                ChoiceTwo TEXT NOT NULL,
                ChoiceThree TEXT NOT NULL,
                ChoiceFour TEXT NOT NULL,
                Completed YESNO DEFAULT FALSE
            );";
            ExecuteSqlNonQuery(createLessonsTable);

            const string createChoicesTable = @"
            CREATE TABLE Choices (
                ChoiceId AUTOINCREMENT PRIMARY KEY,
                LessonId INTEGER NOT NULL,
                ChoiceText TEXT NOT NULL,
                FOREIGN KEY (LessonId) REFERENCES lessonsTable(LessonId)
            );";
            ExecuteSqlNonQuery(createChoicesTable);

            const string createPlayerProgressTable = @"
            CREATE TABLE PlayerProgress (
                PlayerId AUTOINCREMENT PRIMARY KEY,
                LessonId INTEGER NOT NULL,
                CompletionDate DATETIME NOT NULL,
                FOREIGN KEY (LessonId) REFERENCES lessonsTable(LessonId)
            );";
            ExecuteSqlNonQuery(createPlayerProgressTable);
        }

        public static Lesson GetRandomIncompleteLesson()
        {
            const string query = "SELECT TOP 1 LessonId, Topic, Title, Question, CorrectAnswerIndex, Reward, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour " +
                                 "FROM lessonsTable WHERE Completed = False ORDER BY RND(-Timer() * LessonId)";

            Lesson lesson = null;

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lesson = new Lesson(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), false);
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error fetching random lesson: {ex.Message}", @"Database Error", 2000);
                }
            }

            return lesson;
        }

        public static void MarkLessonComplete(int lessonId)
        {
            const string insertQuery = "INSERT INTO PlayerProgress (LessonId, CompletionDate) VALUES (@LessonId, @CompletionDate)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@LessonId", lessonId },
                { "@CompletionDate", DateTime.Now }
            };
            ExecuteDatabaseCommand(insertQuery, parameters);
        }

        public static void AddLesson(Lesson lesson)
        {
            try
            {
                int lessonId = InsertLesson(lesson);
                InsertChoices(lessonId, lesson);
            }
            catch (Exception ex)
            {
                Program.ShowAutoClosingMessageBox($@"Error adding lesson: {ex.Message}", @"Database Error", 2000);
            }
        }

        private static int InsertLesson(Lesson lesson)
        {
            const string insertLessonQuery = @"
                INSERT INTO lessonsTable (Topic, Title, Question, CorrectAnswerIndex, Reward, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour, Completed) 
                VALUES (@Topic, @Title, @Question, @CorrectAnswerIndex, @Reward, @ChoiceOne, @ChoiceTwo, @ChoiceThree, @ChoiceFour, False)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Topic", lesson.Topic },
                { "@Title", lesson.Title },
                { "@Question", lesson.Question },
                { "@CorrectAnswerIndex", lesson.CorrectAnswerIndex },
                { "@Reward", lesson.Reward },
                { "@ChoiceOne", lesson.ChoiceOne },
                { "@ChoiceTwo", lesson.ChoiceTwo },
                { "@ChoiceThree", lesson.ChoiceThree },
                { "@ChoiceFour", lesson.ChoiceFour }
            };

            ExecuteDatabaseOperation(insertLessonQuery, parameters);
            return (int)new OleDbCommand("SELECT @@IDENTITY").ExecuteScalar();
        }

        private static void InsertChoices(int lessonId, Lesson lesson)
        {
            const string insertChoiceQuery = "INSERT INTO Choices (LessonId, ChoiceText) VALUES (@LessonId, @ChoiceText)";
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                conn.Open();
                foreach (string choice in new List<string> { lesson.ChoiceOne, lesson.ChoiceTwo, lesson.ChoiceThree, lesson.ChoiceFour })
                {
                    OleDbCommand choiceCmd = new OleDbCommand(insertChoiceQuery, conn);
                    choiceCmd.Parameters.AddWithValue("@LessonId", lessonId);
                    choiceCmd.Parameters.AddWithValue("@ChoiceText", choice);
                    choiceCmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddNewDayOfIncome(DateTime dateInput, float goldInput, float lumberInput, float diamondsInput, int numberOfPropertiesInput)
        {
            const string insertQuery = "INSERT INTO incomeHistoryTable ([Date], Gold, Lumber, Diamonds, [Number Of Properties]) " +
                                       "VALUES (@DateInput, @GoldInput, @LumberInput, @DiamondsInput, @NumberOfPropertiesInput)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@DateInput", dateInput.ToShortDateString() },
                { "@GoldInput", goldInput },
                { "@LumberInput", lumberInput },
                { "@DiamondsInput", diamondsInput },
                { "@NumberOfPropertiesInput", numberOfPropertiesInput }
            };

            ExecuteDatabaseCommand(insertQuery, parameters);
        }

        public static void AddNewProperty(int propertyId, string propertyType, int xCoordinate, int yCoordinate, float goldCost, float lumberCost, float dailyGoldGain, float dailyLumberGain, float dailyDiamondGain, float totalGoldGain, float totalLumberGain, bool propertyActive)
        {
            string coordinate = $"({xCoordinate},{yCoordinate})";
            const string insertQuery = "INSERT INTO Properties (Id, [Property Type], Coordinate, Active, [Gold Cost], [Lumber Cost], [Daily Gold Gain], [Daily Lumber Gain], [Daily Diamond Gain], [Total Gold Gain], [Total Lumber Gain]) " +
                                       "VALUES (@propertyID, @PropertyType, @coordinate, @Active, @GoldCost, @LumberCost, @DailyGoldGain, @DailyLumberGain, @DailyDiamondGain, @TotalGoldGain, @TotalLumberGain)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@propertyID", propertyId },
                { "@PropertyType", propertyType },
                { "@Coordinate", coordinate },
                { "@Active", propertyActive },
                { "@GoldCost", goldCost },
                { "@LumberCost", lumberCost },
                { "@DailyGoldGain", dailyGoldGain },
                { "@DailyLumberGain", dailyLumberGain },
                { "@DailyDiamondGain", dailyDiamondGain },
                { "@TotalGoldGain", totalGoldGain },
                { "@TotalLumberGain", totalLumberGain }
            };

            ExecuteDatabaseCommand(insertQuery, parameters);
        }

        public static void UpdatePropertyActiveStatus(int xCoord, int yCoord, bool activeOrNot)
        {
            string coordinateOfProperty = $"({xCoord},{yCoord})";
            const string updateQuery = "UPDATE Properties SET Active = @Active WHERE Coordinate = @Coordinate ";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Active", activeOrNot },
                { "@Coordinate", coordinateOfProperty }
            };

            ExecuteDatabaseCommand(updateQuery, parameters);
        }

        public static void UpdatePropertyConnectedStatus(int xCoord, int yCoord, bool connectedOrNot)
        {
            string coordinateOfProperty = $"({xCoord},{yCoord})";
            const string updateQuery = "UPDATE Properties SET Connected = @Connected WHERE Coordinate = @Coordinate";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Connected", connectedOrNot },
                { "@Coordinate", coordinateOfProperty }
            };

            ExecuteDatabaseCommand(updateQuery, parameters);
        }


        public static void UpdateLessonStatus(int lessonId, bool completedOrNot)
        {
            const string updateQuery = "UPDATE lessonsTable SET Completed = @Completed WHERE LessonId = @LessonId";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Completed", completedOrNot },
                { "@LessonId", lessonId }
            };

            ExecuteDatabaseCommand(updateQuery, parameters);
        }

        public static void UpdateDatabaseWithSortedProperties(List<Property> sortedProperties)
        {
            const string deleteQuery = "DELETE FROM Properties";
            ExecuteSqlNonQuery(deleteQuery);

            foreach (Property property in sortedProperties)
            {
                AddNewProperty(property.GetPropertyId(), property.GetType().Name, property.GetXCoordinate(), property.GetYCoordinate(), property.GetGoldCost(), property.GetLumberCost(), property.GetDailyGoldGain(), property.GetDailyLumberGain(), property.GetDailyDiamondGain(), property.GetTotalGoldGain(), property.GetTotalLumberGain(), property.GetActive());
            }
        }

        public static void UpdatePropertyTotalIncome(int propertyXCoordinate, int propertyYCoordinate, float propertyTotalGoldGain, float propertyTotalLumberGain)
        {
            string coordinateOfProperty = $"({propertyXCoordinate},{propertyYCoordinate})";
            const string updateQuery = "UPDATE Properties SET [Total Gold Gain] = @TotalGoldGain, [Total Lumber Gain] = @TotalLumberGain WHERE Coordinate = @Coordinate";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@TotalGoldGain", propertyTotalGoldGain },
                { "@TotalLumberGain", propertyTotalLumberGain },
                { "@Coordinate", coordinateOfProperty }
            };

            ExecuteDatabaseCommand(updateQuery, parameters);
        }

        public static void UpdatePropertyIncomes(int getXCoordinate, int getYCoordinate, float getDailyGoldGain, float getDailyLumberGain, float getDailyDiamondGain)
        {
            string coordinateOfProperty = $"({getXCoordinate},{getYCoordinate})";
            const string updateQuery = "UPDATE Properties SET [Daily Gold Gain] = @DailyGoldGain, [Daily Lumber Gain] = @DailyLumberGain, [Daily Diamond Gain] = @DailyDiamondGain WHERE Coordinate = @Coordinate";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@DailyGoldGain", getDailyGoldGain },
                { "@DailyLumberGain", getDailyLumberGain },
                { "@DailyDiamondGain", getDailyDiamondGain },
                { "@Coordinate", coordinateOfProperty }
            };

            ExecuteDatabaseCommand(updateQuery, parameters);
        }

        private static void ExecuteDatabaseCommand(string query, Dictionary<string, object> parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // dynamically add parameters
                        if (parameters != null)
                            foreach (KeyValuePair<string, object> param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error executing database command: {ex.Message}", @"Database Error", 2000);
                }
            }
        }

        private static void ExecuteDatabaseOperation(string query, Dictionary<string, object> parameters = null, Action<OleDbCommand> commandAction = null)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, object> param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        commandAction?.Invoke(cmd);
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error executing database operation: {ex.Message}", @"Database Error", 2000);
                }
            }
        }
    }
}
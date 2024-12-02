using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using ADOX;

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
                if (!File.Exists(Database))
                {
                    // Create a catalog object
                    Catalog cat = new Catalog();

                    // Create the database
                    cat.Create(ConnectionString);
                }
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
            string query = "SELECT LessonId, Completed, Title, Question FROM lessonsTable";
            return ExecuteQuery(query);
        }

        private static DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            adapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error executing query: {ex.Message}", @"Database Error", 2000);
                }
            }
            return null;
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

        private static void ExecuteSqlNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowAutoClosingMessageBox($@"Error executing SQL query: {query} - {ex.Message}", @"Database Error", 2000);
            }
        }

        private static void CreateTables()
        {
            string createPropertiesTable = @"
            CREATE TABLE Properties (
                Id AUTOINCREMENT PRIMARY KEY,
                [Property Type] TEXT NOT NULL,
                Coordinate TEXT NOT NULL,
                [Gold Cost] INTEGER NOT NULL,
                [Lumber Cost] INTEGER NOT NULL,
                [Daily Gold Gain] INTEGER NOT NULL,
                [Daily Lumber Gain] INTEGER NOT NULL,
                [Daily Diamond Gain] INTEGER NOT NULL
            );";
            ExecuteSqlNonQuery(createPropertiesTable);

            string createIncomeHistoryTable = @"
            CREATE TABLE incomeHistoryTable (
                [Date] DATETIME NOT NULL PRIMARY KEY,
                Gold INTEGER NOT NULL,
                Lumber INTEGER NOT NULL,
                Diamonds INTEGER NOT NULL,
                [Number Of Properties] INTEGER NOT NULL
            );";

            ExecuteSqlNonQuery(createIncomeHistoryTable);

            string createLessonsTable = @"
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

            string createChoicesTable = @"
            CREATE TABLE Choices (
                ChoiceId AUTOINCREMENT PRIMARY KEY,
                LessonId INTEGER NOT NULL,
                ChoiceText TEXT NOT NULL,
                FOREIGN KEY (LessonId) REFERENCES lessonsTable(LessonId)
            );";
            ExecuteSqlNonQuery(createChoicesTable);

            string createPlayerProgressTable = @"
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
            string query = "SELECT TOP 1 LessonId, Topic, Title, Question, CorrectAnswerIndex, Reward, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour " +
                           "FROM lessonsTable WHERE Completed = False ORDER BY RND(-Timer() * LessonId)";

            Lesson lesson = new Lesson();

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
                                lesson.LessonId = reader.GetInt32(0);
                                lesson.Topic = reader.GetString(1);
                                lesson.Title = reader.GetString(2);
                                lesson.Question = reader.GetString(3);
                                lesson.CorrectAnswerIndex = reader.GetInt32(4);
                                lesson.Reward = reader.GetInt32(5);
                                lesson.ChoiceOne = reader.GetString(6);
                                lesson.ChoiceTwo = reader.GetString(7);
                                lesson.ChoiceThree = reader.GetString(8);
                                lesson.ChoiceFour = reader.GetString(9);
                                lesson.Completed = false;
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
            string insertQuery = "INSERT INTO PlayerProgress (LessonId, CompletionDate) VALUES (@LessonId, @CompletionDate)";

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@LessonId", lessonId);
                        cmd.Parameters.AddWithValue("@CompletionDate", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error marking lesson complete: {ex.Message}", @"Database Error", 2000);
                }
            }
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
            string insertLessonQuery = @"
                INSERT INTO lessonsTable (Topic, Title, Question, CorrectAnswerIndex, Reward, ChoiceOne, ChoiceTwo, ChoiceThree, ChoiceFour, Completed) 
                VALUES (@Topic, @Title, @Question, @CorrectAnswerIndex, @Reward, @ChoiceOne, @ChoiceTwo, @ChoiceThree, @ChoiceFour, False)";

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(insertLessonQuery, conn);
                cmd.Parameters.AddWithValue("@Topic", lesson.Topic);
                cmd.Parameters.AddWithValue("@Title", lesson.Title);
                cmd.Parameters.AddWithValue("@Question", lesson.Question);
                cmd.Parameters.AddWithValue("@CorrectAnswerIndex", lesson.CorrectAnswerIndex);
                cmd.Parameters.AddWithValue("@Reward", lesson.Reward);
                cmd.Parameters.AddWithValue("@ChoiceOne", lesson.ChoiceOne);
                cmd.Parameters.AddWithValue("@ChoiceTwo", lesson.ChoiceTwo);
                cmd.Parameters.AddWithValue("@ChoiceThree", lesson.ChoiceThree);
                cmd.Parameters.AddWithValue("@ChoiceFour", lesson.ChoiceFour);
                cmd.ExecuteNonQuery();
                return (int)new OleDbCommand("SELECT @@IDENTITY", conn).ExecuteScalar();
            }
        }

        private static void InsertChoices(int lessonId, Lesson lesson)
        {
            string insertChoiceQuery = "INSERT INTO Choices (LessonId, ChoiceText) VALUES (@LessonId, @ChoiceText)";
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                conn.Open();
                foreach (var choice in new List<string> { lesson.ChoiceOne, lesson.ChoiceTwo, lesson.ChoiceThree, lesson.ChoiceFour })
                {
                    OleDbCommand choiceCmd = new OleDbCommand(insertChoiceQuery, conn);
                    choiceCmd.Parameters.AddWithValue("@LessonId", lessonId);
                    choiceCmd.Parameters.AddWithValue("@ChoiceText", choice);
                    choiceCmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddNewDayOfIncome(DateTime DateInput, float GoldInput, float LumberInput, float DiamondsInput, int NumberOfPropertiesInput)
        {
            string insertQuery = "INSERT INTO incomeHistoryTable ([Date], Gold, Lumber, Diamonds, [Number Of Properties]) " +
                                 "VALUES (@DateInput, @GoldInput, @LumberInput, @DiamondsInput, @NumberOfPropertiesInput)";

            using (OleDbConnection command = new OleDbConnection(ConnectionString))
            {
                try
                {
                    command.Open();
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, command))
                    {
                        cmd.Parameters.AddWithValue("@DateInput", DateInput.ToShortDateString());
                        cmd.Parameters.AddWithValue("@GoldInput", GoldInput);
                        cmd.Parameters.AddWithValue("@LumberInput", LumberInput);
                        cmd.Parameters.AddWithValue("@DiamondsInput", DiamondsInput);
                        cmd.Parameters.AddWithValue("@NumberOfPropertiesInput", NumberOfPropertiesInput);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error adding new day of income: {ex.Message}", @"Database Error", 2000);
                }
            }
        }

        public static void AddNewProperty(string propertyType, int xCoordinate, int yCoordinate, int goldCost, int lumberCost, int dailyGoldGain, int dailyLumberGain, int dailyDiamondGain)
        {
            string coordinate = $"({xCoordinate},{yCoordinate})";
            string insertQuery = "INSERT INTO Properties ([Property Type], Coordinate, [Gold Cost], [Lumber Cost], [Daily Gold Gain], [Daily Lumber Gain], [Daily Diamond Gain]) " +
                                 "VALUES (@PropertyType, @coordinate, @GoldCost, @LumberCost, @DailyGoldGain, @DailyLumberGain, @DailyDiamondGain)";

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PropertyType", propertyType);
                        cmd.Parameters.AddWithValue("@Coordinate", coordinate);
                        cmd.Parameters.AddWithValue("@GoldCost", goldCost);
                        cmd.Parameters.AddWithValue("@LumberCost", lumberCost);
                        cmd.Parameters.AddWithValue("@DailyGoldGain", dailyGoldGain);
                        cmd.Parameters.AddWithValue("@DailyLumberGain", dailyLumberGain);
                        cmd.Parameters.AddWithValue("@DailyDiamondGain", dailyDiamondGain);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error adding new property: {ex.Message}", @"Database Error", 2000);
                }
            }
        }

        public static void UpdateLessonStatus(int lessonID, bool completedOrNot)
        {
            string updateQuery = "UPDATE lessonsTable SET Completed = @Completed WHERE LessonId = @LessonId";

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Completed", completedOrNot);
                        cmd.Parameters.AddWithValue("@LessonId", lessonID);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Program.ShowAutoClosingMessageBox($@"Error updating lesson status: {ex.Message}", @"Database Error", 2000);
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
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
                MessageBox.Show($@"An error occurred: {ex.Message}", @"Database Creation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($@"Error deleting database: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable LoadLessonStatus()
        {
            string query = "SELECT LessonId, Question, Completed FROM lessonsTable";
            return ExecuteQuery(query);
        }

        public static DataTable ExecuteQuery(string query)
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error executing query: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }


        public static DataTable LoadDatabaseData(string whichTable)
        {

            if (whichTable == "temp")
            {

            }

            else
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
                        MessageBox.Show($@"Error loading data: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return null;
        }

        private static void ExecuteSqlNonQuery(string sSqlString)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(ConnectionString))
                {
                    cnn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sSqlString, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Error executing SQL: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string query = "SELECT TOP 1 LessonId, Topic, Question, Reward FROM lessonsTable WHERE Completed = False ORDER BY RND(LessonId)";
            //                                                                  ^ this is causing an error (FROM)
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
                                lesson = new Lesson(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error fetching random lesson: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lesson;
        }

        /*
        public static Lesson GetRandomIncompleteLesson()
        {
            string query = "SELECT TOP 1 LessonId, Topic, Title, Question, CorrectAnswerIndex, Reward, Completed FROM Lessons WHERE Completed = False ORDER BY RND(LessonId)";
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
                                lesson = new Lesson
                                {
                                    LessonId = reader.GetInt32(0),
                                    Topic = reader.GetString(1),
                                    Title = reader.GetString(2),
                                    Question = reader.GetString(3),
                                    CorrectAnswerIndex = reader.GetInt32(4),
                                    Reward = reader.GetInt32(5),
                                    Completed = reader.GetBoolean(6), // Ensure you're fetching Completed field
                                    Choices = new List<string>(), // Initialize Choices (you may fetch these if needed later)
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error fetching random lesson: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lesson;
        }
*/
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
                    MessageBox.Show($@"Error marking lesson complete: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        public static void AddLesson(string topic, string title, string question, int correctAnswerIndex, int reward, List<string> choices)
        {
            string insertLessonQuery = "INSERT INTO lessonsTable (Topic, Title, Question, CorrectAnswerIndex, Reward) " +
                                       "VALUES (@Topic, @Title, @Question, @CorrectAnswerIndex, @Reward)";

            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(insertLessonQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Topic", topic);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Question", question);
                        cmd.Parameters.AddWithValue("@CorrectAnswerIndex", correctAnswerIndex);
                        cmd.Parameters.AddWithValue("@Reward", reward);
                        cmd.ExecuteNonQuery();

                        // Retrieve the LessonId of the newly inserted lesson
                        cmd.CommandText = "SELECT @@IDENTITY";
                        int lessonId = (int)cmd.ExecuteScalar();

                        // Add choices to the Choices table
                        foreach (var choice in choices)
                        {
                            string insertChoiceQuery = "INSERT INTO Choices (LessonId, ChoiceText) VALUES (@LessonId, @ChoiceText)";
                            using (OleDbCommand choiceCmd = new OleDbCommand(insertChoiceQuery, conn))
                            {
                                choiceCmd.Parameters.AddWithValue("@LessonId", lessonId);
                                choiceCmd.Parameters.AddWithValue("@ChoiceText", choice);
                                choiceCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"Error adding lesson: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($@"Error adding new day of income: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show($@"Error adding new property: {ex.Message}", @"Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
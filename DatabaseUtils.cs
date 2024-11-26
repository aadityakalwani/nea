using System;
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
                    MessageBox.Show($@"Error loading data: {ex.Message}", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
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
        private const string Database = "bobFinalDatabase.mdb";
        private const string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source=" + Database + ";";

        public static void InitializeDatabase()
        {
            DeleteDatabase();
            CreateDatabase();
            CreateTables();
            InsertInitialData();
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
                    cat.Create(CONNECTION_STRING);
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
                MessageBox.Show($@"Error deleting database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable LoadData()
        {
            string query = "SELECT * FROM Properties"; // SQL query to fetch all records from the Properties table

            using (OleDbConnection conn = new OleDbConnection(CONNECTION_STRING))
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
                    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return null;
        }

        private static void ExecuteSqlNonQuery(string sSqlString)
        {
            try
            {
                using (OleDbConnection cnn = new OleDbConnection(CONNECTION_STRING))
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
                PropertyType TEXT NOT NULL,
                XCoordinate INTEGER NOT NULL,
                YCoordinate INTEGER NOT NULL,
                GoldCost INTEGER NOT NULL,
                LumberCost INTEGER NOT NULL,
                DailyGoldGain INTEGER NOT NULL,
                DailyLumberGain INTEGER NOT NULL,
                DailyDiamondGain INTEGER NOT NULL
            );";
            ExecuteSqlNonQuery(createPropertiesTable);
        }

        private static void InsertInitialData()
        {
            // Check if data already exists to prevent duplicates
            string checkData = "SELECT COUNT(*) FROM Properties";
            using (OleDbConnection conn = new OleDbConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(checkData, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        // Only insert initial data if table is empty
                        string insertSawmill = "INSERT INTO Properties (PropertyType, XCoordinate, YCoordinate, GoldCost, LumberCost, DailyGoldGain, DailyLumberGain, DailyDiamondGain) " +
                                               "VALUES ('Sawmill', 10, 20, 100, 200, 0, 50, 0)";
                        string insertHouse = "INSERT INTO Properties (PropertyType, XCoordinate, YCoordinate, GoldCost, LumberCost, DailyGoldGain, DailyLumberGain, DailyDiamondGain) " +
                                             "VALUES ('House', 15, 25, 150, 100, 10, 0, 0)";
                        ExecuteSqlNonQuery(insertSawmill);
                        ExecuteSqlNonQuery(insertHouse);
                    }
                }
            }
        }

        public static void AddNewProperty(string propertyType, int xCoordinate, int yCoordinate, int goldCost, int lumberCost, int dailyGoldGain, int dailyLumberGain, int dailyDiamondGain)
        {
            string insertQuery = "INSERT INTO Properties (PropertyType, XCoordinate, YCoordinate, GoldCost, LumberCost, DailyGoldGain, DailyLumberGain, DailyDiamondGain,) " +
                                 "VALUES (@PropertyType, @XCoordinate, @YCoordinate, @GoldCost, @LumberCost, @DailyGoldGain, @DailyLumberGain, @DailyDiamondGain)";

            using (OleDbConnection conn = new OleDbConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@PropertyType", propertyType);
                        cmd.Parameters.AddWithValue("@XCoordinate", xCoordinate);
                        cmd.Parameters.AddWithValue("@YCoordinate", yCoordinate);
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
using System;
using System.IO;
using System.Windows.Forms;
using ADOX;

namespace bobFinal
{
    public static class DatabaseUtils
    {
        private const string Database = "bobFinalDatabase.mdb";
        private const string CONNECTION_STRING = @"Provider=Microsoft Jet 4.0 OLE DB Provider;Data Source=" + Database + ";";

        public static void CreateDatabase()
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

                    // Cleanup
                    cat = null;
                }
            }
            catch (Exception ex)
            {
                // Show a message box only if an error occurs
                MessageBox.Show($@"An error occurred: {ex.Message}", @"Database Creation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
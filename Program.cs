using System;
using System.Threading.Tasks;
using System.Windows.Forms;

// ReSharper disable All

namespace bobFinal
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static async void ShowAutoClosingMessageBox(string message, string title, int timeout)
        {
            Task task = Task.Run(() => MessageBox.Show(message, title));
            await Task.Delay(timeout);
            if (!task.IsCompleted)
            {
                SendKeys.SendWait("{ENTER}"); // Simulates pressing "OK"
            }
        }
    }
}
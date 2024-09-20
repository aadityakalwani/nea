using System;
using System.Windows.Forms;

namespace bobFinal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public abstract class Property
    {
        public string Name { get; set; }
        public int GoldCost { get; set; }
        public int LumberCost { get; set; }
        public int WeeklyGain { get; set; }

        public abstract void Advertise();
    }

    public class House : Property
    {
        public House()
        {
            Name = "House";
            GoldCost = 100;
            LumberCost = 50;
            WeeklyGain = 30;
        }

        public override void Advertise()
        {
            // tk to do later
        }


    }

    public class Resource
    {
        public string Name { get; set; }
        public int Value { get; private set; }
        public int Maximum { get; set; }
        private ProgressBar progressBar;
        private TextBox textBox;

        public Resource(string name, int initialValue, int maximum, ProgressBar progressBar, TextBox textBox)
        {
            Name = name;
            Value = initialValue;
            Maximum = maximum;
            this.progressBar = progressBar;
            this.textBox = textBox;
            UpdateUI();
        }

        public void ChangeQuantity(int amount)
        {
            Value = Math.Max(0, Math.Min(Value + amount, Maximum));
            UpdateUI();
        }

        private void UpdateUI()
        {
            progressBar.Maximum = Maximum;
            progressBar.Value = Value;
            textBox.Text = $"{Value}/{Maximum}";
        }
    }

    public class Farm : Property
    {
        public Farm()
        {
            Name = "Farm";
            GoldCost = 100;
            LumberCost = 100;
            WeeklyGain = 60;
        }

        public override void Advertise()
        {
            // again to do later
        }
    }
}
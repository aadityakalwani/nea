using System;
using System.Collections.Generic;
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
        public int GoldCost { get; protected set; }
        public int LumberCost { get; protected set; }
        public int DailyGoldGain { get; protected set; }
        public int DailyLumberGain { get; protected set; }
        public int DailyDiamondGain { get; protected set; }
        public string ImageFileName { get; protected set; }
    }

    public class House : Property
    {
        public House()
        {
            GoldCost = 100;
            LumberCost = 50;
            DailyGoldGain = 30;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "HouseTile.jpg";
        }
    }

    public class Farm : Property
    {
        public Farm()
        {
            GoldCost = 100;
            LumberCost = 100;
            DailyGoldGain = 60;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "FarmTile.jpg";
        }
    }

    public class Sawmill : Property
    {
        public Sawmill()
        {
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 0;
            DailyLumberGain = 30;
            DailyDiamondGain = 0;
            ImageFileName = "SawmillTile.jpg";
        }
    }

    public class Mine : Property
    {
        public Mine()
        {
            GoldCost = 400;
            LumberCost = 200;
            DailyGoldGain = 200;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "MineTile.jpg";
        }
    }

    public class Cafe : Property
    {
        public Cafe()
        {
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 100;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "CafeTile.jpg";
        }
    }

    public class Resource
    {
        public string Name { get; }
        public int Value { get; private set; }
        public int MaxValue { get; }
        public ProgressBar ProgressBar { get; }
        public TextBox TextBox { get; }
        public int ConversionRate { get; set; }

        public Resource(string name, int value, int maxValue, ProgressBar progressBar, TextBox textBox, int conversionRate)
        {
            Name = name;
            Value = value;
            MaxValue = maxValue;
            ProgressBar = progressBar;
            TextBox = textBox;
            ConversionRate = conversionRate;
            UpdateUI();
        }

        public void ChangeQuantity(int amount)
        {
            Value = Math.Max(0, Math.Min(MaxValue, Value + amount));
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (Value == MaxValue)
            {
                ProgressBar.Value = ProgressBar.Maximum;
            }
            else if (Value == 0)
            {
                ProgressBar.Value = ProgressBar.Minimum;
            }
            else
            {
                ProgressBar.Value = Value * ProgressBar.Maximum / MaxValue;
            }

            TextBox.Text = Value.ToString();
        }
    }

    public static class Market
    {
        private static Random random = new Random();

        public static void UpdateConversionRates(List<Resource> resources)
        {
            foreach (var resource in resources)
            {
                // Fluctuate the conversion rate by +/- 10%
                int fluctuation = random.Next(-10, 11);
                resource.ConversionRate += resource.ConversionRate * fluctuation / 100;

                // ensure the conversion rate is at least 1
                if (resource.ConversionRate < 1)
                {
                    resource.ConversionRate = 1;
                }
            }
        }
    }

}
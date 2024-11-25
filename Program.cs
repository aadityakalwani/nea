using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
    }

    public class CustomPictureBox : PictureBox
    {
        public bool BuiltUpon { get; set; }
    }

    public abstract class Property
    {
        protected Property(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int GoldCost { get; protected set; }
        public int LumberCost { get; protected set; }
        public int DailyGoldGain { get; protected set; }
        public int DailyLumberGain { get; protected set; }
        public int DailyDiamondGain { get; protected set; }
        public string ImageFileName { get; protected set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
    }

    public class House : Property
    {
        public House(int x, int y) : base(x, y)
        {
            GoldCost = 100;
            LumberCost = 50;
            DailyGoldGain = 30;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/HouseTile.jpg";
        }
    }

    public class Farm : Property
    {
        public Farm(int x, int y) : base(x, y)
        {
            GoldCost = 100;
            LumberCost = 100;
            DailyGoldGain = 60;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/FarmTile.jpg";
        }
    }

    public class Sawmill : Property
    {
        public Sawmill(int x, int y) : base(x, y)
        {
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 0;
            DailyLumberGain = 30;
            DailyDiamondGain = 0;
            ImageFileName = "Images/SawmillTile.jpg";
        }
    }

    public class Mine : Property
    {
        public Mine(int x, int y) : base(x, y)
        {
            GoldCost = 400;
            LumberCost = 200;
            DailyGoldGain = 200;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/MineTile.jpg";
        }
    }

    public class Cafe : Property
    {
        public Cafe(int x, int y) : base(x, y)
        {
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 100;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/CafeTile.jpg";
        }
    }

    public class Resource
    {
        public Resource(string name, float value, int maxValue, ProgressBar progressBar, TextBox textBox, float conversionRate)
        {
            Name = name;
            Value = value;
            MaxValue = maxValue;
            ProgressBar = progressBar;
            TextBox = textBox;
            ConversionRate = conversionRate;
            UpdateUi();
        }

        public string Name { get; }
        private float Value { get; set; }
        private int MaxValue { get; set; }
        private ProgressBar ProgressBar { get; }
        private TextBox TextBox { get; }
        public float ConversionRate { get; set; }

        public float getValue()
        {
            return Value;
        }

        public float getConversionRate()
        {
            return ConversionRate;
        }

        public string getName()
        {
            return Name;
        }

        public void ChangeQuantity(float amount)
        {
            Value = Math.Max(0, Math.Min(MaxValue, Value + amount));
            UpdateUi();
        }

        public void IncreaseCapacity(int amount)
        {
            MaxValue += amount;
            UpdateUi();
        }

        private void UpdateUi()
        {
            if (Value >= MaxValue)
                ProgressBar.Value = ProgressBar.Maximum;
            else if (Value == 0)
                ProgressBar.Value = ProgressBar.Minimum;
            else
                ProgressBar.Value = (int)(Value * ProgressBar.Maximum / MaxValue);

            TextBox.Text = $@"{Math.Round(Value, 2)} / {MaxValue}";
        }
    }

    public static class Market
    {
        private static readonly customRandom customRandom = new customRandom();

        public static void UpdateConversionRates(List<Resource> resources)
        {
            foreach (var resource in resources)
            {
                // fluctuate the conversion rate by upto +/- 10%
                var fluctuation = customRandom.Next(-10, 11);
                resource.ConversionRate += resource.ConversionRate * fluctuation / 100;

                // ensure the conversion rate is at least 1
                if (resource.ConversionRate < 1) resource.ConversionRate = 1;
            }
        }
    }

    public class customRandom
    {
        public customRandom() { }

        // Method to generate the next random number in the range [min, max)
        public int Next(int min, int max)
        {
            // use the current time's ticks and some operations
            // 1 tick = 1 x 10^-7 seconds
            long currentTicks = DateTime.Now.Ticks;

            // increase variability and ensure the result is within the range
            long value = currentTicks % (max - min) + min;

            return (int)value;
        }
    }
}
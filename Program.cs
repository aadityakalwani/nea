using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Name { get; private set; }
        public int Value { get; private set; }
        public int MaxValue { get; private set; }
        private ProgressBar progressBar;
        private TextBox textBox;

        public Resource(string name, int initialValue, int maxValue, ProgressBar progressBar, TextBox textBox)
        {
            Name = name;
            Value = initialValue;
            MaxValue = maxValue;
            this.progressBar = progressBar;
            this.textBox = textBox;
            UpdateUI();
        }

        public void ChangeQuantity(int amount)
        {
            Value = Math.Max(0, Math.Min(MaxValue, Value + amount));
            UpdateUI();
        }

        private void UpdateUI()
        {
            progressBar.Maximum = MaxValue;
            progressBar.Value = Value;
            textBox.Text = $"{Value}/{MaxValue}";
        }
    }

    public class Market
    {
        private List<MarketItem> items;

        public Market()
        {
            items = new List<MarketItem>
            {
                new MarketItem("Gold", 100),
                new MarketItem("Lumber", 50),
                new MarketItem("Diamond", 500)
            };
        }

        public List<MarketItem> GetItems()
        {
            return items;
        }

        public void FluctuatePrices()
        {
            Random rand = new Random();
            foreach (var item in items)
            {
                int fluctuation = rand.Next(-10, 11); // Random fluctuation between -10 and +10
                item.Price = Math.Max(1, item.Price + fluctuation); // Ensure price doesn't go below 1
            }
        }

        public bool BuyItem(string itemName, int quantity, Resource dollars)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null && dollars.Value >= item.Price * quantity)
            {
                dollars.ChangeQuantity(-item.Price * quantity);
                return true;
            }
            return false;
        }

        public bool SellItem(string itemName, int quantity, Resource dollars)
        {
            var item = items.FirstOrDefault(i => i.Name == itemName);
            if (item != null)
            {
                dollars.ChangeQuantity(item.Price * quantity);
                return true;
            }
            return false;
        }

    }

    public class MarketItem
    {
        public string Name { get; private set; }
        public int Price { get; set; }

        public MarketItem(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

}
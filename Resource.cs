using System;
using System.Windows.Forms;

namespace bobFinal
{
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

        public float GetValue()
        {
            return Value;
        }

        public float GetConversionRate()
        {
            return ConversionRate;
        }

        public string GetName()
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
}
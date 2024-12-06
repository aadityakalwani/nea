using System;

namespace bobFinal
{
    public class CustomRandom
    {
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
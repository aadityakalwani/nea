using System;

namespace bobFinal
{
    public class CustomRandom
    {
        // Method to generate the next random number in the range [min, max)
        public static float Next(float min, float max)
        {
            // use the current time's milliseconds and some operations to generate a random number
            float currentTicks = DateTime.Now.Millisecond;

            // increase variability and ensure the result is within the range
            float value = currentTicks % (max - min) + min;

            return value;
        }
    }
}
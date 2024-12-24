using System.Collections.Generic;

namespace bobFinal
{
    public static class Market
    {
        public static void UpdateConversionRates(List<Resource> resources)
        {
            foreach (Resource resource in resources)
            {
                // fluctuate the conversion rate by upto +/- 10%
                float fluctuation = CustomRandom.Next(-10, 11);
                resource.ConversionRate += resource.ConversionRate * fluctuation / 100;

                // ensure the conversion rate is at least 1
                if (resource.ConversionRate < 1) resource.ConversionRate = 1;
            }
        }
    }
}
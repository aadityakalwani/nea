﻿namespace bobFinal.PropertiesFolder
{
    public class Mine : Property
    {
        public Mine(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 350;
            LumberCost = 250;
            DailyGoldGain = 150;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/MineTile.jpg";
            Active = true;
        }

        protected override string GetPropertyDetails()
        {
            return base.GetPropertyDetails() + $", Gold Cost: {GetGoldCost()}, Lumber Cost: {GetLumberCost()}, Daily Gold Gain: {DailyGoldGain}, Daily Lumber Gain: {DailyLumberGain}";
        }

        public override void SetPropertyCosts(float goldCost, float lumberCost)
        {
            GoldCost = goldCost;
            LumberCost = lumberCost;
        }
    }
}
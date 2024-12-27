namespace bobFinal.PropertiesClasses
{
    public class Farm : Property
    {
        public Farm(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 150;
            LumberCost = 100;
            DailyGoldGain = 40;
            DailyLumberGain = 10;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/FarmTile.jpg";
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
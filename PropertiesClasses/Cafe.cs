namespace bobFinal.PropertiesClasses
{
    public class Cafe : Property
    {
        public Cafe(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 250;
            LumberCost = 150;
            DailyGoldGain = 100;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/CafeTile.jpg";
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
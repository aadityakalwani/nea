namespace bobFinal.PropertiesClasses
{
    public class Sawmill : Property
    {
        public Sawmill(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 100;
            LumberCost = 100;
            DailyGoldGain = 0;
            DailyLumberGain = 40;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/SawmillTile.jpg";
            Active = true;
        }

        public override string GetPropertyDetails()
        {
            return base.GetPropertyDetails() + $", Gold Cost: {GetGoldCost()}, Lumber Cost: {GetLumberCost()}, Daily Gold Gain: {DailyGoldGain}, Daily Lumber Gain: {DailyLumberGain}";
        }
    }
}
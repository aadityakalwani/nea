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
            DailyLumberGain = 30;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/SawmillTile.jpg";
            Active = true;
        }
    }
}
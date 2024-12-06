namespace bobFinal
{
    public class Sawmill : Property
    {
        public Sawmill(int id, int x, int y) : base(x, y)
        {
            PropertyID = id;
            GoldCost = 100;
            LumberCost = 100;
            DailyGoldGain = 0;
            DailyLumberGain = 30;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/SawmillTile.jpg";
            active = true;
        }
    }
}
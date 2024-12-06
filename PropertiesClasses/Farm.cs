namespace bobFinal
{
    public class Farm : Property
    {
        public Farm(int id, int x, int y) : base(x, y)
        {
            PropertyID = id;
            GoldCost = 120;
            LumberCost = 100;
            DailyGoldGain = 50;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/FarmTile.jpg";
            active = true;
        }
    }
}
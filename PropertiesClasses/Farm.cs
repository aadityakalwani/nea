namespace bobFinal
{
    public class Farm : Property
    {
        public Farm(int x, int y) : base(x, y)
        {
            GoldCost = 100;
            LumberCost = 100;
            DailyGoldGain = 60;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/FarmTile.jpg";
            active = true;
        }
    }
}
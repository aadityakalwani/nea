namespace bobFinal
{
    public class Mine : Property
    {
        public Mine(int id, int x, int y) : base(x, y)
        {
            PropertyID = id;
            GoldCost = 400;
            LumberCost = 200;
            DailyGoldGain = 200;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/MineTile.jpg";
            active = true;
        }
    }
}
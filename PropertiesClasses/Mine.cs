namespace bobFinal
{
    public class Mine : Property
    {
        public Mine(int x, int y) : base(x, y)
        {
            GoldCost = 400;
            LumberCost = 200;
            DailyGoldGain = 200;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/MineTile.jpg";
            active = true;
        }
    }
}
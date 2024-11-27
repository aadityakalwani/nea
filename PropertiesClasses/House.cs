namespace bobFinal
{
    public class House : Property
    {
        public House(int x, int y) : base(x, y)
        {
            GoldCost = 100;
            LumberCost = 50;
            DailyGoldGain = 30;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            ImageFileName = "Images/HouseTile.jpg";
        }
    }
}
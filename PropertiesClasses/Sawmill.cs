namespace bobFinal
{
    public class Sawmill : Property
    {
        public Sawmill(int x, int y) : base(x, y)
        {
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 0;
            DailyLumberGain = 30;
            DailyDiamondGain = 0;
            ImageFileName = "Images/SawmillTile.jpg";
            active = true;
        }
    }
}
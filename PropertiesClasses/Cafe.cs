namespace bobFinal.PropertiesClasses
{
    public class Cafe : Property
    {
        public Cafe(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 200;
            LumberCost = 100;
            DailyGoldGain = 100;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/CafeTile.jpg";
            Active = true;
        }
    }
}
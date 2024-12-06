namespace bobFinal.PropertiesClasses
{
    public class House : Property
    {
        public House(int id, int x, int y) : base(x, y)
        {
            PropertyId = id;
            GoldCost = 100;
            LumberCost = 50;
            DailyGoldGain = 30;
            DailyLumberGain = 0;
            DailyDiamondGain = 0;
            TotalGoldGain = 0;
            TotalLumberGain = 0;
            ImageFileName = "Images/HouseTile.jpg";
            Active = true;
        }
    }
}
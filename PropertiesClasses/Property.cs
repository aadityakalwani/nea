namespace bobFinal
{
    public abstract class Property
    {
        protected Property(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        public int PropertyID { get; protected set; }
        public int GoldCost { get; protected set; }
        public int LumberCost { get; protected set; }
        public int DailyGoldGain { get; protected set; }
        public int DailyLumberGain { get; protected set; }
        public int DailyDiamondGain { get; protected set; }
        public int TotalGoldGain { get; set; }
        public int TotalLumberGain { get; set; }
        public string ImageFileName { get; protected set; }
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public bool active { get; set; }
    }
}
namespace bobFinal.PropertiesClasses
{
    public abstract class Property
    {
        protected Property(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        protected int PropertyID;
        protected int GoldCost;
        protected int LumberCost;
        protected int DailyGoldGain;
        protected int DailyLumberGain;
        protected int DailyDiamondGain;
        protected int TotalGoldGain;
        protected int TotalLumberGain;
        protected string ImageFileName;
        protected readonly int XCoordinate;
        protected readonly int YCoordinate;
        protected bool active;

        public int getPropertyID()
        {
            return PropertyID;
        }

        public int getGoldCost()
        {
            return GoldCost;
        }

        public int getLumberCost()
        {
            return LumberCost;
        }

        public int getDailyGoldGain()
        {
            return DailyGoldGain;
        }

        public int getDailyLumberGain()
        {
            return DailyLumberGain;
        }

        public int getDailyDiamondGain()
        {
            return DailyDiamondGain;
        }

        public int getTotalGoldGain()
        {
            return TotalGoldGain;
        }

        public void increaseTotalGoldGain(int amount)
        {
            TotalGoldGain += amount;
        }

        public int getTotalLumberGain()
        {
            return TotalLumberGain;
        }

        public void increaseTotalLumberGain(int amount)
        {
            TotalGoldGain += amount;
        }

        public string getImageFileName()
        {
            return ImageFileName;
        }

        public int getXCoordinate()
        {
            return XCoordinate;
        }

        public int getYCoordinate()
        {
            return YCoordinate;
        }

        public bool getActive()
        {
            return active;
        }

        public void setActive(bool newCondition)
        {
            active = newCondition;
        }

    }
}
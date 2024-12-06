namespace bobFinal.PropertiesClasses
{
    public abstract class Property
    {
        protected Property(int x, int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }

        protected int PropertyId;
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
        protected bool Active;

        public int GetPropertyId()
        {
            return PropertyId;
        }

        public int GetGoldCost()
        {
            return GoldCost;
        }

        public int GetLumberCost()
        {
            return LumberCost;
        }

        public int GetDailyGoldGain()
        {
            return DailyGoldGain;
        }

        public int GetDailyLumberGain()
        {
            return DailyLumberGain;
        }

        public int GetDailyDiamondGain()
        {
            return DailyDiamondGain;
        }

        public int GetTotalGoldGain()
        {
            return TotalGoldGain;
        }

        public void IncreaseTotalGoldGain(int amount)
        {
            TotalGoldGain += amount;
        }

        public int GetTotalLumberGain()
        {
            return TotalLumberGain;
        }

        public void IncreaseTotalLumberGain(int amount)
        {
            TotalLumberGain += amount;
        }

        public string GetImageFileName()
        {
            return ImageFileName;
        }

        public int GetXCoordinate()
        {
            return XCoordinate;
        }

        public int GetYCoordinate()
        {
            return YCoordinate;
        }

        public bool GetActive()
        {
            return Active;
        }

        public void SetActive(bool newCondition)
        {
            Active = newCondition;
        }

    }
}
namespace bobFinal.PropertiesClasses
{
    public abstract class Property
    {
        private readonly int xCoordinate;
        private readonly int yCoordinate;
        protected bool Active;
        protected bool Connected;
        protected float DailyDiamondGain;
        protected float DailyGoldGain;
        protected float DailyLumberGain;
        protected float GoldCost;
        protected string ImageFileName;
        protected float LumberCost;
        protected int PropertyId;
        protected float TotalGoldGain;
        protected float TotalLumberGain;

        protected Property(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }

        public int GetPropertyId()
        {
            return PropertyId;
        }

        public float GetGoldCost()
        {
            return GoldCost;
        }

        public float GetLumberCost()
        {
            return LumberCost;
        }

        public float GetDailyGoldGain()
        {
            return DailyGoldGain;
        }

        public float GetDailyLumberGain()
        {
            return DailyLumberGain;
        }

        public float GetDailyDiamondGain()
        {
            return DailyDiamondGain;
        }

        public void SetDailyGoldGain(float newDailyGoldAmount)
        {
            DailyGoldGain = newDailyGoldAmount;
        }

        public void SetDailyLumberGain(float newDailyLumberAmount)
        {
            DailyLumberGain = newDailyLumberAmount;
        }

        public void SetDailyDiamondGain(float newDailyDiamondAmount)
        {
            DailyDiamondGain = newDailyDiamondAmount;
        }

        public float GetTotalGoldGain()
        {
            return TotalGoldGain;
        }

        public void IncreaseTotalGoldGain(float amount)
        {
            TotalGoldGain += amount;
        }

        public float GetTotalLumberGain()
        {
            return TotalLumberGain;
        }

        public void IncreaseTotalLumberGain(float amount)
        {
            TotalLumberGain += amount;
        }

        public string GetImageFileName()
        {
            return ImageFileName;
        }

        public int GetXCoordinate()
        {
            return xCoordinate;
        }

        public int GetYCoordinate()
        {
            return yCoordinate;
        }

        public bool GetActive()
        {
            return Active;
        }

        public void SetActive(bool newCondition)
        {
            Active = newCondition;
        }

        public bool GetConnected()
        {
            return Connected;
        }

        public void SetConnected(bool newCondition)
        {
            Connected = newCondition;
        }
    }
}
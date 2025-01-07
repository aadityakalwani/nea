namespace bobFinal.PropertiesFolder
{
    public abstract class Property : IProperty, IGridEntity
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;
        private bool _connected;
        protected bool Active;
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
            _xCoordinate = x;
            _yCoordinate = y;
        }


        // IGridEntity Implementation
        public int GetXCoordinate()
        {
            return _xCoordinate;
        }

        public int GetYCoordinate()
        {
            return _yCoordinate;
        }

        public bool GetConnected()
        {
            return _connected;
        }

        public void SetConnected(bool newCondition)
        {
            _connected = newCondition;
        }

        // IProperty Implementation
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

        public bool GetActive()
        {
            return Active;
        }

        public void SetActive(bool newCondition)
        {
            Active = newCondition;
        }

        // virtual method to be overridden by subclasses to allow for unique property details
        protected virtual string GetPropertyDetails()
        {
            return $"Property ID: {PropertyId}, Coordinates: ({_xCoordinate}, {_yCoordinate})";
        }

        public abstract void SetPropertyCosts(float goldCost, float lumberCost);
    }
}
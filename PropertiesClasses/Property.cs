using System.Windows.Forms;

namespace bobFinal.PropertiesClasses
{
    public abstract class Property
    {
        protected Property(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }

        protected int PropertyId;
        protected float GoldCost;
        protected float LumberCost;
        protected float DailyGoldGain;
        protected float DailyLumberGain;
        protected float DailyDiamondGain;
        protected float TotalGoldGain;
        protected float TotalLumberGain;
        protected string ImageFileName;
        private readonly int xCoordinate;
        private readonly int yCoordinate;
        protected bool Active;

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

        public void SetGoldCost(float newGoldCost)
        {
            GoldCost = newGoldCost;
        }

        public void SetLumberCost(float newLumberCost)
        {
            LumberCost = newLumberCost;
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
    }
}
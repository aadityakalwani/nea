namespace bobFinal.PropertiesClasses
{
    public interface IPropertyInterface
    {
        int GetPropertyId();
        float GetGoldCost();
        float GetLumberCost();
        float GetDailyGoldGain();
        float GetDailyLumberGain();
        float GetDailyDiamondGain();
        void SetDailyGoldGain(float newDailyGoldAmount);
        void SetDailyLumberGain(float newDailyLumberAmount);
        void SetDailyDiamondGain(float newDailyDiamondAmount);
        float GetTotalGoldGain();
        void IncreaseTotalGoldGain(float amount);
        float GetTotalLumberGain();
        void IncreaseTotalLumberGain(float amount);
        string GetImageFileName();
        int GetXCoordinate();
        int GetYCoordinate();
        bool GetActive();
        void SetActive(bool newCondition);
        bool GetConnected();
        void SetConnected(bool newCondition);
    }
}
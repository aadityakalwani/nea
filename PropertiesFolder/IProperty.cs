namespace bobFinal.PropertiesFolder
{
    public interface IProperty
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
        bool GetActive();
        void SetActive(bool newCondition);
    }
}
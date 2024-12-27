namespace bobFinal
{
    public interface IGridEntity
    {
        int GetXCoordinate();
        int GetYCoordinate();
        bool GetConnected();
        void SetConnected(bool connected);
    }
}
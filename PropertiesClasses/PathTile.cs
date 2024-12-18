namespace bobFinal.PropertiesClasses
{
    public class PathTile
    {
        private readonly int xCoordinate;
        private readonly int yCoordinate;
        public string imageFileName;

        public PathTile(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            imageFileName = "Images/pathTile.jpg";
        }

        public int GetXCoordinate()
        {
            return xCoordinate;
        }

        public int GetYCoordinate()
        {
            return yCoordinate;
        }

        public string GetImageFileName()
        {
            return imageFileName;
        }
    }
}
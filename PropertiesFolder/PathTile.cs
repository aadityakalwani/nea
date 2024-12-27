namespace bobFinal.PropertiesFolder
{
    public class PathTile
    {
        private readonly string imageFileName;
        private readonly int xCoordinate;
        private readonly int yCoordinate;

        public PathTile(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
            imageFileName = "Images/PathTile.jpg";
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

        public override string ToString()
        {
            return $"Path Tile at ({xCoordinate}, {yCoordinate})";
        }
    }
}
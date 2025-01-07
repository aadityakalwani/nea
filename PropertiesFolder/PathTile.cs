namespace bobFinal.PropertiesFolder
{
    public class PathTile
    {
        private readonly string _imageFileName;
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;

        public PathTile(int x, int y)
        {
            _xCoordinate = x;
            _yCoordinate = y;
            _imageFileName = "Images/PathTile.jpg";
        }

        public int GetXCoordinate()
        {
            return _xCoordinate;
        }

        public int GetYCoordinate()
        {
            return _yCoordinate;
        }

        public string GetImageFileName()
        {
            return _imageFileName;
        }

        public override string ToString()
        {
            return $"Path Tile at ({_xCoordinate}, {_yCoordinate})";
        }
    }
}
namespace Battleship.UI.Utilities
{
    public static class CoordinateHelper
    {
        public static Coordinate Parse(string coordinate)
        {
            int x = (int)coordinate[0] - 64;

            int y = int.Parse(coordinate.Substring(1));

            return new Coordinate(x, y);

        }

        public static int ConvertToIndex(Coordinate coordinate)
        {
            int index = 10 * (coordinate.Y - 1) + (coordinate.X - 1);

            return index;
        }
    }
}
namespace Battleship.BLL
{
    public struct Coordinate
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Coordinate ToCoordinate(string str)
        {
            int x = str[0] - 64;
            int y = int.Parse(str.Substring(1));

            return new Coordinate(x, y);
        }

        public static int ToBoardIndex(Coordinate c)
        {
            int index = 10 * (c.Y - 1) + (c.X - 1);

            return index;
        }

        public override string ToString()
        {
            char col = (char)(X + 64);
            int row = Y;


            return $"{col}{row}";
        }
    }
}
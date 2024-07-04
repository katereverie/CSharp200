namespace Battleship.UI
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            char col;
            int row = Y;

            switch (X)
            {
                case 1:
                    col = 'A';
                    break;
                case 2:
                    col = 'B';
                    break;
                case 3:
                    col = 'C';
                    break;
                case 4:
                    col = 'D';
                    break;
                case 5:
                    col = 'E';
                    break;
                case 6:
                    col = 'F';
                    break;
                case 7:
                    col = 'G';
                    break;
                case 8:
                    col = 'H';
                    break;
                case 9:
                    col = 'I';
                    break;
                case 10:
                    col = 'J';
                    break;
                default:
                    col = 'N';
                    break;
            }

            return $"{col}{row}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Coordinate)
            {
                Coordinate other = (Coordinate)obj;

                return other.X == X && other.Y == Y;
            }

            return false;
        }
    }
}
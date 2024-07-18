namespace Battleship.BLL
{
    public class Ship
    {
        public string Name { get; }
        public char Symbol { get; }
        public int Size { get; }
        public int HitCount { get; private set; }
        public bool IsSunk { get; private set; }
        public Coordinate[] Coordinates { get; }

        public Ship(string name, int size)
        {
            Name = name;
            Symbol = name[0];
            Size = size;
            HitCount = 0;
            IsSunk = false;
            Coordinates = new Coordinate[size];
        }

        public void SetCoordinates(Coordinate startingCoord, char dir)
        {

            if (dir == 'V')
            {
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    Coordinates[i] = new Coordinate(startingCoord.X, startingCoord.Y + i);
                }
            }

            if (dir == 'H')
            {
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    Coordinates[i] = new Coordinate(startingCoord.X + i, startingCoord.Y);
                }
            }
        }

        public void CountHit()
        {
            HitCount++;

            if (HitCount == Size)
            {
                IsSunk = true;
            }
        }
    }
}
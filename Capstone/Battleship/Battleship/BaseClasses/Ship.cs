namespace Battleship.UI.BaseClasses
{
    public class Ship
    {
        public string Name { get; private set; }
        public char Symbol { get; private set; }
        public int Size { get; private set; }
        public int HitCount { get; private set; }
        public bool IsSunk { get; private set; }
        public Coordinate[] Coordinates { get; set; }

        public Ship(string name, int size)
        {
            Name = name;
            Symbol = name[0];
            Size = size;
            HitCount = 0;
            IsSunk = false;
            Coordinates = new Coordinate[size];
        }

        public void SetCoordinates(Coordinate startingCoordinate, char direction)
        {

            if (direction == 'V')
            {
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X, startingCoordinate.Y + i);
                }
            }

            if (direction == 'H')
            {
                for (int i = 0; i < Coordinates.Length; i++)
                {
                    Coordinates[i] = new Coordinate(startingCoordinate.X + i, startingCoordinate.Y);
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
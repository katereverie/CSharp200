using Battleship.UI.Interfaces;
using Battleship.UI.BaseClasses;

namespace Battleship.UI.Implementations.Players
{
    public class ComputerPlayer : IPlayer
    {
        private Random _generator = new Random();

        public string Name { get; } = "Capt. Dee G. Tall";
        public bool IsHuman { get; } = false;
        public Ship[] Ships { get; private set; } = new Ship[5];
        public List<Coordinate> Shots { get; private set; } = new List<Coordinate>();
        public char[] GameBoard {  get; }

        public Coordinate DecideCoordinate(string prompt)
        {
            throw new NotImplementedException("A computer player doesn't need prompting.");
        }

        public Coordinate DecideCoordinate()
        {
            int x = _generator.Next(1, 11);
            int y = _generator.Next(1, 11);

            return new Coordinate(x, y);
        }

        public char DecideDirection()
        {
            return _generator.Next(1, 3) == 1? 'V' : 'H';
        }

        public void AddShip(Ship shipToAdd)
        {
            for (int i = 0; i < Ships.Length; i++)
            {
                if (Ships[i] == null)
                {
                    Ships[i] = shipToAdd;
                    return;
                }
            }

        }

        public void PlaceShot(Coordinate targetShot)
        {
            Shots.Add(targetShot);
        }

        public void UpdateGameBoard(char shotSymbol, int index)
        {
            throw new Exception("Computer player doesn't need to update the Game Board.");
        }
    }
}
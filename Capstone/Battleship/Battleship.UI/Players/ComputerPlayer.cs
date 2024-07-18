using Battleship.BLL.Interfaces;
using Battleship.BLL;

namespace Battleship.UI.Players
{
    public class ComputerPlayer : IPlayer
    {
        private Random _generator = new Random();

        public string Name { get; } = "Capt. Dee G. Tall";
        public bool IsHuman { get; } = false;
        public List<Ship> Ships { get; set; } = new();
        public List<Coordinate> Shots { get; set; } = new();
        public char[] ShotBoard { get; } = new char[100];

        public Coordinate GetCoordinate(string prompt)
        {
            int x = _generator.Next(1, 11);
            int y = _generator.Next(1, 11);

            return new Coordinate(x, y);
        }

        public char GetDirection()
        {
            return _generator.Next(1, 3) == 1? 'V' : 'H';
        }
    }
}
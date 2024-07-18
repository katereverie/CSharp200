using Battleship.BLL.Interfaces;
using Battleship.BLL;

namespace Battleship.UI.Players
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; } = "Capt. " +  GameConsole.GetPlayerName("What's Your Name? Your name: ");
        public bool IsHuman { get; } = true;
        public List<Ship> Ships { get; set; } = new();
        public List<Coordinate> Shots { get; set; } = new();
        public char[] ShotBoard { get; set; } = new char[100];

        public Coordinate GetCoordinate(string prompt)
        {
            return Coordinate.ToCoordinate(GameConsole.GetStringCoordinate(prompt));
        }

        public char GetDirection()
        {
            return GameConsole.GetDirection();
        }
    }
}
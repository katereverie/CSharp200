using Battleship.BLL.Interfaces;
using Battleship.BLL;

namespace Battleship.UI.Players
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; } = "Capt. " +  GameConsole.GetPlayerName("What's Your Name? Your name: ");
        public bool IsHuman { get; } = true;
        public List<Ship> Ships { get; private set; } = new();
        public List<Coordinate> Shots { get; set; } = new();
        public char[] ShotBoard { get; set; } = new char[100];

        public Coordinate GetCoordinate(string prompt)
        {
            string validCoordinate = GameConsole.GetStringCoordinate(prompt);

            return Coordinate.ToCoordinate(validCoordinate);
        }

        public char GetDirection()
        {
            return GameConsole.GetDirection();
        }

        public void PlaceShip(Ship shipToPlace)
        {
            Ships.Add(shipToPlace);
        }

        public void UpdateShotBoard(char shotSymbol, int index)
        {
            ShotBoard[index] = shotSymbol;
        }
    }
}
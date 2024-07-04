using Battleship.UI.BaseClasses;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Implementations.Players
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; } = "Capt. " +  ConsoleIO.GetPlayerName("What's Your Name? Your name: ");
        public bool IsHuman { get; } = true;
        public Ship[] Ships {  get; private set; } = new Ship[5];
        public List<Coordinate> Shots { get; private set; } = new List<Coordinate>();
        public char[] GameBoard { get; set; } = new char[100];

        public Coordinate DecideCoordinate(string prompt)
        {
            string validCoordinate = ConsoleIO.GetStringCoordinate(prompt);

            return CoordinateHelper.Parse(validCoordinate);
        }

        public Coordinate DecideCoordinate()
        {
            throw new NotImplementedException("A human player needs prompting. This is for AI players only.");
        }

        public char DecideDirection()
        {
            return ConsoleIO.GetDirection();
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
            GameBoard[index] = shotSymbol;
        }
    }
}
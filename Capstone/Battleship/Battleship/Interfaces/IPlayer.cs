using Battleship.UI.BaseClasses;

namespace Battleship.UI.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        bool IsHuman { get; }
        Ship[] Ships { get; }
        List<Coordinate> Shots { get; }
        char[] GameBoard {  get; }

        // a player can add ship and place a shot
        Coordinate DecideCoordinate(string prompt);
        Coordinate DecideCoordinate();
        char DecideDirection();
        void AddShip(Ship ship);
        void PlaceShot(Coordinate targetShot);
        void UpdateGameBoard(char shotSymbol, int index);
    }
}
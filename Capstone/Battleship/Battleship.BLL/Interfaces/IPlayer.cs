namespace Battleship.BLL.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        bool IsHuman { get; }
        List<Ship> Ships { get; }
        List<Coordinate> Shots { get; }
        char[] ShotBoard {  get; }

        // a player can add ship and place a shot
        Coordinate GetCoordinate(string prompt);
        char GetDirection();
        void PlaceShip(Ship shipToPlace);
        void UpdateShotBoard(char shotSymbol, int index);
    }
}
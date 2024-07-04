using Battleship.UI.BaseClasses;
using Battleship.UI.Utilities;

namespace Battleship.UI.Logic
{
    public class GameManager
    {
        public PlacementResult CheckOffgridShip(Ship shipToPlace)
        {
            for (int i = 0; i < shipToPlace.Size; i++)
            {
                if (shipToPlace.Coordinates[i].X > 10 || shipToPlace.Coordinates[i].Y > 10)
                {
                    return PlacementResult.Offgrid;
                }
            }

            return PlacementResult.Placed;
        }

        public PlacementResult CheckOverlapShip(Ship shipToAdd, Ship[] ships)
        {
            foreach (Ship ship in ships)
            {
                if (ship == null)
                {
                    continue;
                }

                foreach (Coordinate coordinate in ship.Coordinates)
                {
                    if (shipToAdd.Coordinates.Contains(coordinate))
                    {
                        return PlacementResult.Overlap;
                    }
                }
            }

            return PlacementResult.Added;
        }

        public PlacementResult CheckOverlapShot(Coordinate shot, List<Coordinate> Shots)
        {
            if (Shots == null || !Shots.Contains(shot))
            {
                return PlacementResult.Placed;
            }

            return PlacementResult.Overlap;

        }

        public ShotResult EvaluateValidShot(Coordinate validShot, Ship[] otherPlayerShips)
        {

            foreach (Ship ship in otherPlayerShips)
            {
                if (ship.Coordinates.Contains(validShot))
                {
                    ship.CountHit();
                    return ship.IsSunk ? ShotResult.Sunk : ShotResult.Hit;
                }
            }

            return ShotResult.Miss;
        }

        public int CalculateRemainingShips(Ship[] Ships)
        {
            int remainingShips = 5;

            foreach (Ship ship in Ships)
            {
                if (ship.IsSunk)
                {
                    remainingShips--;
                }
            }

            return remainingShips;

        }

        public int CalculateRemainingHits(Ship[] Ships)
        {
            int remainingHits = 17;

            foreach(Ship ship in Ships)
            {
                remainingHits -= ship.HitCount;
            }
            
            return remainingHits;
        }

        public char[] MapShipsToBoard(char[] shipBoard, Ship[] ships)
        {

            foreach (Ship ship in ships)
            {
                if (ship != null)
                {
                    foreach (Coordinate coordinate in ship.Coordinates)
                    {
                        int index = CoordinateHelper.ConvertToIndex(coordinate);
                        shipBoard[index] = ship.Symbol;
                    } 
                    
                }
                else
                {
                    continue;
                }
            }

            return shipBoard;
        }
    }
}
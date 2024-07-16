namespace Battleship.BLL
{
    public static class GameManager
    {
        public static PlacementResult CheckOffgridShip(Coordinate startingCoord, int size, char dir)
        {
            if (dir == 'V')
            {
                return startingCoord.Y + size > 11 ? PlacementResult.Offgrid : PlacementResult.Placed;
            }

            return startingCoord.X + size > 11 ? PlacementResult.Offgrid : PlacementResult.Placed;
        }

        public static PlacementResult CheckOverlapShip(Ship shipToAdd, List<Ship> ships)
        {

            foreach (Ship ship in ships)
            {
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

        public static PlacementResult CheckOverlapShot(Coordinate shot, List<Coordinate> Shots)
        {
            if (Shots == null || !Shots.Contains(shot))
            {
                return PlacementResult.Placed;
            }

            return PlacementResult.Overlap;

        }

        public static ShotResult EvaluateValidShot(Coordinate validShot, List<Ship> otherPlayerShips)
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

        public static int CalculateRemainingShips(List<Ship> ships)
        {
            int remainingShips = 5;

            foreach (Ship ship in ships)
            {
                if (ship.IsSunk)
                {
                    remainingShips--;
                }
            }

            return remainingShips;
        }

        public static int CalculateRemainingHits(List<Ship> Ships)
        {
            int remainingHits = 17;

            foreach(Ship ship in Ships)
            {
                remainingHits -= ship.HitCount;
            }
            
            return remainingHits;
        }

        public static char[] MapShipsToBoard(char[] shipBoard, List<Ship> ships)
        {
            if (ships != null)
            {
                foreach (Ship ship in ships)
                {
                    foreach (Coordinate coordinate in ship.Coordinates)
                    {
                        int index = Coordinate.ToBoardIndex(coordinate);
                        shipBoard[index] = ship.Symbol;
                    }
                }
            }

            return shipBoard;
        }
    }
}
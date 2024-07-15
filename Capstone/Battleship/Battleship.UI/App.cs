using Battleship.BLL;
using Battleship.BLL.Interfaces;
using Battleship.BLL.Ships;

namespace Battleship.UI
{

    public class App
    {
        private Random _startDecider = new Random();
        private GameManager _mgr = new GameManager();
        private IPlayer _p1;
        private IPlayer _p2;

        public App ()
        {
            _p1 = PlayerFactory.GetPlayer(1);
            _p2 = PlayerFactory.GetPlayer(2);
        }

        private void PlaceShip(IPlayer player, Ship shipToPlace)
        {
            if (player.IsHuman)
            {
                char[] shipBoard = new char[100];
                GameConsole.PrintShipPlacementRules();
                Console.WriteLine($"\nAhoy! {player.Name}, let's place your ships!");

                shipBoard = _mgr.MapShipsToBoard(shipBoard, player.Ships);
                GameConsole.PrintBoard(shipBoard);

                // exit loop only if player's placement is valid under all conditions
                while (true)
                {
                    Console.WriteLine($"Ship to place: {shipToPlace.Name} | Size: {shipToPlace.Size}");
                    Coordinate startingCoordinate = player.GetCoordinate("Enter a starting coordinate (e.g. A1): ");
                    char direction = player.GetDirection();

                    if (_mgr.CheckOffgridShip(startingCoordinate, shipToPlace.Size, direction) == PlacementResult.Offgrid)
                    {
                        GameConsole.PrintErrorMessage("Ship Offgrid.\n");
                        continue;
                    }

                    shipToPlace.SetCoordinates(startingCoordinate, direction);

                    if (_mgr.CheckOverlapShip(shipToPlace, player.Ships) == PlacementResult.Overlap)
                    {
                        GameConsole.PrintErrorMessage("Ship Overlap.\n");
                        continue;
                    }

                    // since placed ship is neither offgrid nor overlapped, add it to player's ships and print the game board
                    player.PlaceShip(shipToPlace);
                    Console.WriteLine($"You have successfully placed your {shipToPlace.Name}.");
                    if (shipToPlace.Symbol == 'D')
                    {
                        shipBoard = _mgr.MapShipsToBoard(shipBoard, player.Ships);
                        GameConsole.PrintBoard(shipBoard);
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }
            else
            {
                while (true)
                {
                    char dir = player.GetDirection();
                    Coordinate startingCoord = player.GetCoordinate("");
                    if (_mgr.CheckOffgridShip(startingCoord, shipToPlace.Size, dir) == PlacementResult.Offgrid)
                    {
                        continue;
                    }

                    shipToPlace.SetCoordinates(startingCoord, dir);

                    if (_mgr.CheckOverlapShip(shipToPlace, player.Ships) == PlacementResult.Overlap)
                    {
                        continue;
                    }

                    player.PlaceShip(shipToPlace);
                    return;
                }
            }
        }

        private void SetUpPlayer(IPlayer p)
        {
            PlaceShip(p, new AircraftCarrier());
            PlaceShip(p, new BattleShip());
            PlaceShip(p, new Cruiser());
            PlaceShip(p, new Submarine());
            PlaceShip(p, new Destroyer());
        }

        private IPlayer GetNextPlayer(IPlayer currentPlayer)
        {
            return currentPlayer == _p1? _p2 : _p1;
        }

        public void Run()
        {
            GameConsole.AnyKey();
            SetUpPlayer(_p1);
            SetUpPlayer(_p2);

            IPlayer currentPlayer = _startDecider.Next(1, 3) == 1 ? _p1 : _p2;
            IPlayer nextPlayer;
            GameConsole.PrintGameRules();
            Console.WriteLine($"The God of Chance has blessed {currentPlayer.Name} to place the first shot!\n");

            // start game
            while (true)
            {
                nextPlayer = GetNextPlayer(currentPlayer);
                int remainingShips = _mgr.CalculateRemainingShips(nextPlayer.Ships);
                int remainingHits = _mgr.CalculateRemainingHits(nextPlayer.Ships);
                GameConsole.PrintPlayerSummary(nextPlayer, remainingShips, remainingHits);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(currentPlayer.Name);
                Console.ResetColor();
                Console.WriteLine("'s turn.\n");

                GameConsole.PrintBoard(currentPlayer.ShotBoard);

                // Placing shot
                ShotResult shotResult;
                Coordinate shot;

                while (true)
                {
                    shot = currentPlayer.IsHuman ? currentPlayer.GetCoordinate("Enter target coordinate (e.g. A5): ") : currentPlayer.GetCoordinate("");

                    if (_mgr.CheckOverlapShot(shot, currentPlayer.Shots) == PlacementResult.Overlap)
                    {
                        if (currentPlayer.IsHuman)
                        {
                            GameConsole.PrintErrorMessage("Shot Overlap.");
                        }

                        continue;
                    }

                    currentPlayer.Shots.Add(shot);
                    break;
                }

                Console.WriteLine($"{currentPlayer.Name} fires a shot at {shot}...");
                shotResult = _mgr.EvaluateValidShot(shot, nextPlayer.Ships);

                int index = Coordinate.ToBoardIndex(shot);

                switch (shotResult)
                {
                    case ShotResult.Miss:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nSplash! A miss!\n");
                        break;
                    case ShotResult.Hit:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nKABOOM! A hit!\n");
                        break;
                    case ShotResult.Sunk:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nKABOOM!\nGLUG-GLUG-GLUG! A ship sunk!\n");
                        break;
                }

                Console.ResetColor();

                currentPlayer.ShotBoard[index] = shotResult == ShotResult.Miss ? 'M' : 'H';

                // exit game statement
                if (_mgr.CalculateRemainingShips(nextPlayer.Ships) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentPlayer.Name} is the Victor!");
                    Console.ResetColor();
                    return;
                }

                GameConsole.AnyKey();
                GameConsole.PrintGameRules();
                currentPlayer = GetNextPlayer(currentPlayer);
            }
        }
    }
}
using Battleship.UI.Logic;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;
using Battleship.UI.BaseClasses;

namespace Battleship.UI.Workflows
{
    public class App
    {
        private readonly Random _startDecider;
        private readonly GameManager _mgr;
        private readonly IPlayer _p1;
        private readonly IPlayer _p2;

        public App(IPlayer p1, IPlayer p2)
        {
            _startDecider = new Random();
            _mgr = new GameManager();
            _p1 = p1;
            _p2 = p2;
        }

        public void SetUpGame(IPlayer player, Ship ship)
        {
            if (player.IsHuman)
            {
                char[] shipBoard = new char[100];
                ConsoleIO.PrintShipPlacementRules();
                Console.WriteLine($"\nAhoy! {player.Name}, let's place your ships!");

                shipBoard = _mgr.MapShipsToBoard(shipBoard, player.Ships);
                ConsoleIO.PrintBoard(shipBoard);

                // exit loop only if player's placement is valid under all conditions
                while (true)
                {
                    Console.WriteLine($"Ship to place: {ship.Name} | Size: {ship.Size}");
                    Coordinate startingCoordinate = player.DecideCoordinate("Enter a starting coordinate (e.g. A1): ");
                    char direction = player.DecideDirection();
                    ship.SetCoordinates(startingCoordinate, direction);

                    if (_mgr.CheckOffgridShip(ship) == ActionResult.Offgrid)
                    {
                        ConsoleIO.PrintErrorMessage("Ship Offgrid.\n");
                        continue;
                    }

                    if (_mgr.CheckOverlapShip(ship, player.Ships) == ActionResult.Overlap) 
                    {
                        ConsoleIO.PrintErrorMessage("Ship Overlap.\n");
                        continue;
                    }

                    // since placed ship is neither offgrid nor overlapped, add it to player's ships and print the game board
                    player.AddShip(ship);
                    Console.WriteLine($"You have successfully placed your {ship.Name}.");
                    if (ship.Symbol == 'D')
                    {
                        shipBoard = _mgr.MapShipsToBoard(shipBoard, player.Ships);
                        ConsoleIO.PrintBoard(shipBoard);
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
                    char direction = player.DecideDirection();
                    Coordinate startingCoordinate = player.DecideCoordinate();
                    ship.SetCoordinates(startingCoordinate, direction);

                    if (_mgr.CheckOffgridShip(ship) == ActionResult.Offgrid)
                    {
                        continue;
                    } 

                    if (_mgr.CheckOverlapShip(ship, player.Ships) == ActionResult.Overlap)
                    {
                        continue;
                    }

                    player.AddShip(ship);
                    return;
                }
            } 
        }

        private IPlayer GetNextPlayer(IPlayer currentPlayer)
        {
            if (currentPlayer == _p1)
            {
                return _p2;
            }

            return _p1;
        }

        // Game Begins
        public void RunGame()
        {
            IPlayer currentPlayer = _startDecider.Next(1, 3) == 1 ? _p1 : _p2;
            IPlayer nextPlayer;
            ConsoleIO.PrintGameRules();
            Console.WriteLine($"The God of Chance has blessed {currentPlayer.Name} to place the first shot!\n");

            while (true) 
            {
                nextPlayer = GetNextPlayer(currentPlayer);
                int remainingShips = _mgr.CalculateRemainingShips(nextPlayer.Ships);
                int remainingHits = _mgr.CalculateRemainingHits(nextPlayer.Ships);
                ConsoleIO.PrintPlayerSummary(nextPlayer, remainingShips, remainingHits);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(currentPlayer.Name);
                Console.ResetColor();
                Console.WriteLine("'s turn.\n");

                if (currentPlayer.IsHuman)
                {
                    ConsoleIO.PrintBoard(currentPlayer.GameBoard);
                }

                // Placing shot
                ActionResult result;
                Coordinate validShot;

                while (true)
                {
                    Coordinate targetShot = currentPlayer.IsHuman ? currentPlayer.DecideCoordinate("Enter target coordinate (e.g. A5): ") : currentPlayer.DecideCoordinate();
                    result = _mgr.CheckOverlapShot(targetShot, currentPlayer.Shots);

                    if (result == ActionResult.Overlap)
                    {
                        if (currentPlayer.IsHuman)
                        {
                            ConsoleIO.PrintErrorMessage("Shot Overlap.");
                        }

                        continue;
                    }

                    validShot = targetShot;
                    currentPlayer.PlaceShot(targetShot);
                    break;
                }


                Console.WriteLine($"{currentPlayer.Name} fires a shot at {validShot}...");
                result = _mgr.EvaluateValidShot(validShot, nextPlayer.Ships);

                int index = CoordinateHelper.ConvertToIndex(validShot);

                switch (result)
                {
                    case ActionResult.Miss:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\nSplash! A miss!\n");
                        break;
                    case ActionResult.Hit:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nKABOOM! A hit!\n");
                        break;
                    case ActionResult.Sunk:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nKABOOM!\nGLUG-GLUG-GLUG! A ship sunk!\n");
                        break;
                }

                Console.ResetColor();

                if (currentPlayer.IsHuman)
                {
                    currentPlayer.GameBoard[index] = result == ActionResult.Miss ? 'M' : 'H';
                }

                // exit game statement
                if (_mgr.CalculateRemainingShips(nextPlayer.Ships) == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{currentPlayer.Name}, You are the Victor!");
                    Console.ResetColor();
                    return;
                }

                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ConsoleIO.PrintGameRules();
                currentPlayer = GetNextPlayer(currentPlayer);
            }

        }
    }
}
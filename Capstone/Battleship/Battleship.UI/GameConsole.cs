using Battleship.BLL.Interfaces;
using System.Text.RegularExpressions;


namespace Battleship.UI
{
    public static class GameConsole
    {
        private readonly static Regex _coordinateRegex = new Regex(@"^[A-Ja-j](10|[1-9])$");

        public static string GetPlayerName(string prompt)
        {
            string? playerName;

            do
            {
                Console.Write(prompt);

                playerName = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(playerName) && !string.IsNullOrWhiteSpace(playerName))
                {
                    return playerName;
                }

                Console.WriteLine("Even an obscure captain has a name. What's yours?");

            } while (true);
        }

        public static string GetStringCoordinate(string prompt)
        {
            string? input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    PrintErrorMessage($"Invalid Input.");
                    continue;
                }
                else if (!_coordinateRegex.IsMatch(input))
                {
                    PrintErrorMessage("Invalid coordinate format.");
                    continue;
                }

                return input.ToUpper();

            } while (true);
        }

        public static char GetDirection()
        {
            do
            {
                Console.Write("Place ship (V)ertical or (H)orizontal: ");

                if (char.TryParse(Console.ReadLine()?.Trim().ToUpper(), out char dir))
                {
                    if (dir == 'V' || dir == 'H')
                    {
                        return dir;
                    }

                    PrintErrorMessage($"Invalid direction: {dir}");
                    continue;
                }

                PrintErrorMessage("Invalid input.");

            } while (true);
        }

        public static void PrintErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a 10x10 grid of marked symbols
        /// </summary>
        /// <param name="board">takes a char array. This method assumes the argument to be a char array of size 100</param>
        public static void PrintBoard(char[] board)
        {
            // head row
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n     A B C D E F G H I J");
            Console.ResetColor();

            // head column
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                switch (i)
                {
                    case 9:
                        Console.Write($"  {i + 1} ");
                        break;
                    default:
                        Console.Write($"   {i + 1} ");
                        break;
                }

                Console.ResetColor();

                // each grid row
                for (int j = 0; j < 10; j++)
                {
                    int index = i * 10 + j;

                    switch (board[index])
                    {
                        case '\0':
                            Console.Write("- ");
                            break;
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{board[index]} ");
                            Console.ResetColor();
                            break;
                        case 'M':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write($"{board[index]} ");
                            Console.ResetColor();
                            break;
                        case char symbol when symbol != 'H' && symbol != 'M':
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write($"{board[index]} ");
                            Console.ResetColor();
                            break;
                    }
                }
                // go to next row
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintPlayerSelectionRules()
        {
            Console.Write("=========================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Player Selection Rules ");
            Console.ResetColor();
            Console.WriteLine("=========================");
            Console.WriteLine("| You may choose to play with the Computer or with another human player. |");
            Console.WriteLine("| You may not choose two Computer Players to play against each other.    |");
            Console.WriteLine("==========================================================================\n");
        }

        public static void PrintShipPlacementRules()
        {
            Console.Write("===================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Ship Placement Rules ");
            Console.ResetColor();
            Console.WriteLine("===================================");
            Console.WriteLine("| 1. You may only place a ship with on-grid coordinates: from A-J (column) and 1-10 (row). |");
            Console.WriteLine("| 2. You will be prompted for a starting coordinate and placement direction.               |");
            Console.WriteLine("| 3. You may not place a ship that has any coordinate that overlaps with other ships.      |");
            Console.WriteLine("============================================================================================\n");
        }

        public static void PrintGameRules()
        {
            Console.Write("============================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Game Rules ");
            Console.ResetColor();
            Console.WriteLine("============================");
            Console.WriteLine("| 1. You may place only one shot per turn.                         |");
            Console.WriteLine("| 2. You may not repeat placed shots.                              |");
            Console.WriteLine("| 3. Whoever sinks all 5 ships of the other player claims victory. |");
            Console.WriteLine("====================================================================\n");
        }

        public static void PrintPlayerSummary(IPlayer nextPlayer, int remainingShips, int remainingHits)
        {
            Console.WriteLine($"\n{nextPlayer.Name}: | Remaining Ships: {remainingShips} | Remaining Hits: {remainingHits} |\n");
        }
    }
}
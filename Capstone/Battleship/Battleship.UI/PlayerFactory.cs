using Battleship.UI.Players;
using Battleship.BLL.Interfaces;

namespace Battleship.UI
{
    public static class PlayerFactory
    {
        private static int _computerPlayerCount = 0;

        public static IPlayer GetPlayer(int playerNumber)
        {
            string? userChoice;

            do
            {
                Console.Write($"Player {playerNumber}- (H)uman or (C)omputer? Your choice: ");
                userChoice = Console.ReadLine()?.Trim().ToUpper();

                if (userChoice == "H" || userChoice == "C")
                {
                    switch (userChoice)
                    {
                        case "H":
                            return new HumanPlayer();
                        case "C":
                            switch (_computerPlayerCount)
                            {
                                case 1:
                                    Console.WriteLine("At least one player must be human.");
                                    continue;
                                default:
                                    _computerPlayerCount++;
                                    break;
                            }
                            return new ComputerPlayer();
                    }
                }

                GameConsole.PrintErrorMessage("Invalid choice. Please enter either 'H' or 'C'.");

            } while (true);
        }
    }
}
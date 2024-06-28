using Battleship.UI.Implementations.Players;
using Battleship.UI.Interfaces;
using Battleship.UI.Utilities;

namespace Battleship.UI.Workflows
{
    public static class PlayerFactory
    {
        public static IPlayer GetPlayer(string prompt)
        {
            string userChoice;

            do
            {
                Console.Write(prompt);
                userChoice = Console.ReadLine().Trim().ToUpper();

                if (userChoice == "H" || userChoice == "C")
                {
                    switch (userChoice)
                    {
                        case "H":
                            return new HumanPlayer();
                        case "C":
                            return new ComputerPlayer();
                    }
                }

                ConsoleIO.PrintErrorMessage("Invalid choice. Please enter either 'H' or 'C'.");
                
            } while (true);
        }
    }
}
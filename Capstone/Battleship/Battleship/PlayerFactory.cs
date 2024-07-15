using Battleship.UI.Players;
using Battleship.BLL.Interfaces;

namespace Battleship.UI
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

                GameConsole.PrintErrorMessage("Invalid choice. Please enter either 'H' or 'C'.");

            } while (true);
        }
    }
}
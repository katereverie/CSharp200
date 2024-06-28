using TicTacToe.UI.Interfaces;
using TicTacToe.UI.Implementations;

namespace TicTacToe.UI
{
    public static class PlayerFactory
    {
        //TODO-1: Prompt users for what type of players should be in the game: Human or Computer
        // Specifically, prompt users to choose between Human or Computer, for player 1, and player 2
        // It should not matter whether the users choose to watch computer play with itself or to play with another player.


        public static IPlayer GetChoiceForPlayer(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string userChoice = Console.ReadLine().ToUpper();

                if (userChoice == "H")
                {
                    return new HumanPlayer();
                }
                else if (userChoice == "C")
                {
                    return new ComputerPlayer();
                }

                Console.WriteLine("You can only enter either 'H' for Human or 'C' for Computer.");

            } while (true);

        }

    }
}

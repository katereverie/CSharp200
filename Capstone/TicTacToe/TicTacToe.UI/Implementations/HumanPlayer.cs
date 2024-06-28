using TicTacToe.UI.Interfaces;
using TicTacToe.UI.Utilities;

namespace TicTacToe.UI.Implementations
{
    public class HumanPlayer : IPlayer
    {
        // human players need to enter an int representing a valid position (1-9)
        /* Is it the concern of the HumanPlayer implementation to validate position?
         * No. Because it should be the GameManager's responsibility to track which positions have been chosen 
         */
        public char Symbol { get; set; }

        public int GetPosition(char[] currentBoard)
        {
            return ConsoleIO.GetPlayerInput($"{Symbol}, choose a position: ");
        }
    }
}

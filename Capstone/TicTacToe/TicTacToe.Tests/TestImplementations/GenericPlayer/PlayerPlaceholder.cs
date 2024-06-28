using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests.TestImplementations.GenericPlayer
{
    public class PlayerPlaceholder : IPlayer
    {
        public char Symbol { get; set; }

        public int GetPosition(char[] currentBoard)
        {
            return 1;
        }
    }
}

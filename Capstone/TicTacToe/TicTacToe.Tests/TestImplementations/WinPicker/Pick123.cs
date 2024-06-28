using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests.TestImplementations.WinPicker
{
    public class Pick123 : IPlayer
    {
        public int Count { get; private set; } = 0;
        public char Symbol { get; set; }

        public int GetPosition(char[] currentBoard)
        {

            switch (Count)
            {
                case 0:
                    Count++;
                    return 1;
                case 1:
                    Count++;
                    return 2;
                case 2:
                    Count++;
                    return 3;
            }

            return -1;
        }
    }
}

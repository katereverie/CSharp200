using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests.TestImplementations.DrawPicker
{
    public class Pick1678 : IPlayer
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
                    return 6;
                case 2:
                    Count++;
                    return 7;
                case 3:
                    Count++;
                    return 8;
            }

            return -1;
        }
    }
}

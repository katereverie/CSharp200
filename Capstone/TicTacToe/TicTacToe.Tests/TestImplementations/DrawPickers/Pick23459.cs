using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests.TestImplementations.DrawPicker
{
    public class Pick23459 : IPlayer
    {
        public int Count { get; private set; } = 0;

        public char Symbol { get; set; }

        public int GetPosition(char[] currentBoard)
        {

            switch (Count)
            {
                case 0:
                    Count++;
                    return 2;
                case 1:
                    Count++;
                    return 3;
                case 2:
                    Count++;
                    return 4;
                case 3:
                    Count++;
                    return 5;
                case 4:
                    Count++;
                    return 9;
            }

            return -1;
        }
    }
}

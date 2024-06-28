using TicTacToe.UI.Interfaces;

namespace TicTacToe.UI.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        private Random _random = new Random();

        public char Symbol { get; set; }

        public int GetPosition(char[] currentBoard)
        {

            int computerMove;

            /* exit loop only if computer has generated a move 
             * which points to an unoccupied position on the game board
             */
            do
            {
                computerMove = _random.Next(1, 10);

            } while (currentBoard[computerMove - 1] != ' ');

            Console.Write($"{Symbol} chooses position {computerMove}.\n");

            return computerMove;
        }
    }
}


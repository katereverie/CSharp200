namespace TicTacToe.UI.Utilities
{
    public static class ConsoleIO
    {
        public static int GetPlayerInput(string prompt)
        {
            Console.Write(prompt);
            do
            {
                if (int.TryParse(Console.ReadLine(), out int playerMove))
                {
                    return playerMove;
                }

                Console.WriteLine("The chosen position must be numeric.");

            } while (true);
        }

        public static void PrintGameBoard()
        {
            Console.WriteLine("Here's the position of the grid: \n");
            Console.WriteLine(" 1 | 2 | 3 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 4 | 5 | 6 ");
            Console.WriteLine("---+---+---");
            Console.WriteLine(" 7 | 8 | 9 \n");
        }

        public static void PrintUpdatedGameBoard(char[] gameBoard)
        {
            Console.WriteLine($"\n {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} \n");
        }

        /// <summary>
        /// displays only a placement result that is necessary; a successful placement needn't displaying
        /// unless it completes a win pattern, in which case, display which players wins.
        /// </summary>
        /// <param name="result">placement result to display
        /// </param>
        public static void DisplayResult(PlacementResult result)
        {
            switch (result)
            {
                case PlacementResult.InvalidOverlap:
                    Console.WriteLine("The position has already been chosen.");
                    break;
                case PlacementResult.InvalidOffGrid:
                    Console.WriteLine("The position you chose is off grid.");
                    break;
                case PlacementResult.XWins:
                    Console.WriteLine("X wins!");
                    break;
                case PlacementResult.OWins:
                    Console.WriteLine("O wins!");
                    break;
            }
        }
    }
}
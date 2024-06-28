using TicTacToe.UI.GameLogic;
using TicTacToe.UI.Utilities;

namespace TicTacToe.UI.Workflows
{
    public class App
    {
        public static void Run()
        {

            Console.WriteLine("Welcome to Tic-Tac-Toe!\n");


            var player1 = PlayerFactory.GetChoiceForPlayer("Player 1 (X) - Human or Computer? (H/C): ");
            var player2 = PlayerFactory.GetChoiceForPlayer("Player 2 (O) - Human or Computer? (H/C): ");

            GameManager gameManager = new GameManager(player1, player2);
            PlacementResult result;
            int playerMove;
            var currentPlayer = gameManager.DecideWhichPlayerGoesFirst();
            Console.WriteLine($"\nThe God of Chance has spoken:\n{currentPlayer.Symbol} will go first.\n");

            ConsoleIO.PrintGameBoard();

            // exit loop only if a win pattern has been detected or all 9 positions have been taken (draw).
            while (true)
            {
                // exit loop only if a move has been placed successfully.
                while (true)
                {
                    playerMove = currentPlayer.GetPosition(gameManager.GameBoard);
                    result = gameManager.CheckPlacement(playerMove);

                    if (result == PlacementResult.SymbolPlaced)
                    {
                        break;
                    }

                    ConsoleIO.DisplayResult(result);
                }

                gameManager.UpdateGameBoard(playerMove, currentPlayer.Symbol);

                ConsoleIO.PrintUpdatedGameBoard(gameManager.GameBoard);

                if (gameManager.CheckWin())
                {
                    switch (currentPlayer.Symbol)
                    {
                        case 'X':
                            ConsoleIO.DisplayResult(PlacementResult.XWins);
                            break;
                        case 'O':
                            ConsoleIO.DisplayResult(PlacementResult.OWins);
                            break;
                    }

                    return;
                }

                if (gameManager.CheckDraw())
                {
                    ConsoleIO.DisplayResult(PlacementResult.Draw);
                    return;
                }

                // since neither player has won and it's not a draw, get next player
                currentPlayer = gameManager.GetNextPlayer(currentPlayer);

            }
        }
    }
}

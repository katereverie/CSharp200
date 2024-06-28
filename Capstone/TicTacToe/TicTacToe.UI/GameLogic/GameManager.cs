using TicTacToe.UI.Interfaces;
using TicTacToe.UI.Utilities;

namespace TicTacToe.UI.GameLogic
{
    public class GameManager
    {
        private Random _decideFirstMove;
        private int _countMoves; // connected to CheckWin() in order to reduce redundant checking

        public IPlayer Player1 { get; private set; }
        public IPlayer Player2 { get; private set; }
        public char[] GameBoard { get; private set; }

        public GameManager(IPlayer player1, IPlayer player2)
        {
            Player1 = player1;
            Player1.Symbol = 'X';
            Player2 = player2;
            Player2.Symbol = 'O';

            _countMoves = 0;
            _decideFirstMove = new Random();

            GameBoard = new char[9];

            for (int i = 0; i < GameBoard.Length; i++)
            {
                GameBoard[i] = ' ';
            }
        }

        public IPlayer DecideWhichPlayerGoesFirst()
        {
            switch (_decideFirstMove.Next(1, 2))
            {
                case 1: return Player1;
                case 2: return Player2;
            }

            return null;
        }

        public IPlayer GetNextPlayer(IPlayer currentPlayer)
        {
            if (currentPlayer.Equals(Player1))
            {
                return Player2;
            }

            return Player1;
        }


        /// <summary>
        /// validates a player's move by checking if the move is within the range between 1 and 9
        /// </summary>
        /// <param name="playerMove">an integer representing a player move</param>
        /// <returns>the enum PlacementResult.SymbolPlaced if player move is within set range; 
        ///          PlacementResult.InvalidOffGrid if player move is out of set range; 
        ///          PlaceemntResult.InvalidOverlap if player move points to an already taken position on the game board.
        ///          </returns>
        public PlacementResult CheckPlacement(int playerMove)
        {

            if (playerMove < 1 || playerMove > 9)
            {
                return PlacementResult.InvalidOffGrid;
            }
            else if (GameBoard[playerMove - 1] == ' ')
            {
                return PlacementResult.SymbolPlaced;
            }

            return PlacementResult.InvalidOverlap;
        }


        /// <summary>
        /// adds the player symbol to a chosen empty position on the game board.
        /// </summary>
        /// <param name="playerMove">an integer representing the position on the game board</param>
        /// <param name="playerSymbol">a single character representing the player</param>
        public void UpdateGameBoard(int playerMove, char playerSymbol)
        {
            GameBoard[playerMove - 1] = playerSymbol;
            _countMoves++;
        }

        /// <summary>
        /// starts checking win patterns only if 5 or more moves have been placed.
        /// </summary>
        /// <returns>true if any win pattern has been detected in the game board. Otherwise, false.</returns>
        public bool CheckWin()
        {
            if (_countMoves < 5)
            {
                return false;
            }

            // all win patterns 
            if (GameBoard[0] != ' ' && GameBoard[0] == GameBoard[3] && GameBoard[3] == GameBoard[6])
            {
                return true;
            }
            else if (GameBoard[1] != ' ' && GameBoard[1] == GameBoard[4] && GameBoard[4] == GameBoard[7])
            {
                return true;
            }
            else if (GameBoard[2] != ' ' && GameBoard[2] == GameBoard[5] && GameBoard[5] == GameBoard[8])
            {
                return true;
            }
            else if (GameBoard[0] != ' ' && GameBoard[0] == GameBoard[1] && GameBoard[1] == GameBoard[2])
            {
                return true;
            }
            else if (GameBoard[3] != ' ' && GameBoard[3] == GameBoard[4] && GameBoard[4] == GameBoard[5])
            {
                return true;
            }
            else if (GameBoard[6] != ' ' && GameBoard[6] == GameBoard[7] && GameBoard[7] == GameBoard[8])
            {
                return true;
            }
            else if (GameBoard[0] != ' ' && GameBoard[0] == GameBoard[4] && GameBoard[4] == GameBoard[8])
            {
                return true;
            }
            else if (GameBoard[2] != ' ' && GameBoard[2] == GameBoard[4] && GameBoard[4] == GameBoard[6])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// declares draw only if all positions of game board have been taken.
        /// </summary>
        /// <returns>true if 9 moves have been placed. Otherwise, false.</returns>
        public bool CheckDraw()
        {
            if (_countMoves == 9)
            {
                return true;
            }

            return false;
        }

    }
}

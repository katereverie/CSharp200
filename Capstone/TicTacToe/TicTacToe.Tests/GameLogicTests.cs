using NUnit.Framework;
using TicTacToe.Tests.TestImplementations.DrawPicker;
using TicTacToe.Tests.TestImplementations.GenericPlayer;
using TicTacToe.Tests.TestImplementations.WinPicker;
using TicTacToe.UI.GameLogic;
using TicTacToe.UI.Utilities;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameLogicTests
    {

        [Test]
        public void TestInvalidOverlap()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new PlayerPlaceholder());

            mgr.UpdateGameBoard(1, 'X');
            var result = mgr.CheckPlacement(1);

            Assert.AreEqual(PlacementResult.InvalidOverlap, result);
        }

        [Test]
        public void TestInvalidOffGrid()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new PlayerPlaceholder());

            var result = mgr.CheckPlacement(10);

            Assert.AreEqual(PlacementResult.InvalidOffGrid, result);
        }

        [Test]
        public void TestSymbolPlaced()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new PlayerPlaceholder());


            var result1 = mgr.CheckPlacement(7);
            var result2 = mgr.CheckPlacement(6);

            Assert.AreEqual(PlacementResult.SymbolPlaced, result1);
            Assert.AreEqual(PlacementResult.SymbolPlaced, result2);
        }

        [Test]
        public void TestGameManager_SuccessfulGameBoardUpdate()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new PlayerPlaceholder());

            mgr.UpdateGameBoard(9, mgr.Player1.Symbol);
            mgr.UpdateGameBoard(6, mgr.Player2.Symbol);

            var gameBoardPlacementAtIndex8 = mgr.GameBoard[8];
            var gameBoardPlacementAtIndex5 = mgr.GameBoard[5];

            Assert.AreEqual('X', gameBoardPlacementAtIndex8);
            Assert.AreEqual('O', gameBoardPlacementAtIndex5);
        }

        [Test]
        public void TestWinStats_VerticalWin()
        {
            GameManager mgr = new GameManager(new Pick147(), new PlayerPlaceholder());

            mgr.UpdateGameBoard(2, 'X');
            mgr.UpdateGameBoard(3, 'X');
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);

            bool correctGameBoardStatus = mgr.GameBoard[0] == mgr.GameBoard[3] && mgr.GameBoard[3] == mgr.GameBoard[6] && mgr.GameBoard[6] == 'X';

            var result = mgr.CheckWin();

            Assert.IsTrue(result);
            Assert.IsTrue(correctGameBoardStatus);
        }

        [Test]
        public void TestWinStats_HorizontalWin()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new Pick123());

            mgr.UpdateGameBoard(4, 'X');
            mgr.UpdateGameBoard(5, 'X');
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);

            bool correctGameBoardStatus = mgr.GameBoard[0] == mgr.GameBoard[1] && mgr.GameBoard[1] == mgr.GameBoard[2] && mgr.GameBoard[2] == 'O';

            var result = mgr.CheckWin();

            Assert.IsTrue(result);
            Assert.IsTrue(correctGameBoardStatus);
        }

        [Test]
        public void TestWinStats_DiagonalWin()
        {
            GameManager mgr = new GameManager(new PlayerPlaceholder(), new Pick159());

            mgr.UpdateGameBoard(2, 'X');
            mgr.UpdateGameBoard(3, 'X');
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);

            bool correctGameBoardStatus = mgr.GameBoard[0] == mgr.GameBoard[4] && mgr.GameBoard[4] == mgr.GameBoard[8] && mgr.GameBoard[8] == 'O';

            var result = mgr.CheckWin();

            Assert.IsTrue(result);
            Assert.IsTrue(correctGameBoardStatus);
        }

        [Test]
        public void TestWinStats_Draw()
        {
            GameManager mgr = new GameManager(new Pick23459(), new Pick1678());

            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);
            mgr.UpdateGameBoard(mgr.Player2.GetPosition(mgr.GameBoard), mgr.Player2.Symbol);
            mgr.UpdateGameBoard(mgr.Player1.GetPosition(mgr.GameBoard), mgr.Player1.Symbol);


            var winResult = mgr.CheckWin();
            var drawResult = mgr.CheckDraw();

            Assert.IsFalse(winResult);
            Assert.IsTrue(drawResult);
        }

    }
}

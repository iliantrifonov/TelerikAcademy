using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TicTacToe.GameLogic;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameResultTests
    {
        [TestMethod]
        public void WhenHorizontalXHas3_ShouldReturnWinX()
        {
            var board = "XXX--OO--";

            var validator = new GameResultValidator();
            var expected = GameResult.WonByX;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenHorizontalOHas3_ShouldReturnWinO()
        {
            var board = "OOO--XX--";

            var validator = new GameResultValidator();
            var expected = GameResult.WonByO;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenInvalidCountOfMoves_ShouldReturnInvalid()
        {
            var board = "OOOO-XX--";

            var validator = new GameResultValidator();
            var expected = GameResult.Invalid;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenVerticalHas3_ShouldReturnWin()
        {
            var board = "O--OXXO--";

            var validator = new GameResultValidator();
            var expected = GameResult.WonByO;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenRightDiagonalHas3_ShouldReturnWin()
        {
            var board = "O--XOX--O";

            var validator = new GameResultValidator();
            var expected = GameResult.WonByO;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenLeftDiagonalHas3_ShouldReturnWin()
        {
            var board = "--OXOXO--";

            var validator = new GameResultValidator();
            var expected = GameResult.WonByO;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void WhenHasMovesToPlay_ShouldReturnNotFinished()
        {
            var board = "---XOXO--";

            var validator = new GameResultValidator();
            var expected = GameResult.NotFinished;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoneCanPlay_ShouldReturnDraw()
        {
            var board = "XOXXOXOXO";

            var validator = new GameResultValidator();
            var expected = GameResult.Draw;
            var actual = validator.GetResult(board);

            Assert.AreEqual(expected, actual);
        }
    }
}

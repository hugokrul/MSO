//using System;
//using MSO2;
//using Xunit;

//namespace MSO2XUnit
//{
//    public class BoardTests
//    {
//        [Fact]
//        public void TestBoardInstanceReturnsNotNull()
//        {
//            Board.DeleteInstance();
//            Board board = Board.GetInstance();
//            Assert.NotNull(Board.GetInstance());
//        }

//        [Fact]
//        public void TestBoardInstanceReturnsSameBoard()
//        {
//            Board.DeleteInstance();
//            Board board = Board.GetInstance();
//            Board newBoard = Board.GetInstance();
//            Assert.Equal(board, newBoard);
//        }

//        [Fact]
//        public void OutOfUpperBounds()
//        {
//            int boardHeight = Board.boardHeight;
//            int boardWidth = Board.boardWidth;

//            (int, int) newPosition = Board.BoardBounds((boardWidth + 1, boardHeight + 1));

//            Assert.Equal(newPosition, (boardWidth, boardHeight));
//        }

//        [Fact]
//        public void OutOfLowerBounds()
//        {
//            (int, int) newPosition = Board.BoardBounds((-1, -1));
//            Assert.Equal(newPosition, (0, 0));
//        }
//    }
//}

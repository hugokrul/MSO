using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class RepeatUntilTests
    {
        [Fact]
        public void TestWallAhead()
        {
            Board board = new Board(10, 10);
            string[,] boardArray =
            {
                { "s", "+" },
                { "+", "+" }
            };

            Board.BoardArray = boardArray;
            bool wallAhead = RepeatUntilFunctions.WallAhead(board.Player);
            Assert.True(wallAhead);
        }

        [Fact]
        public void TestGridEdgeFacingSouth()
        {
            Board board = new Board(1, 1);
            bool GridEdge= RepeatUntilFunctions.GridEdge(board.Player);
            Assert.True(GridEdge);
        }
        [Fact]
        public void TestGridEdgeFacingNorth()
        {
            Board board = new Board(1, 1);
            board.Player.Turn("left"); board.Player.Turn("left");
            bool GridEdge = RepeatUntilFunctions.GridEdge(board.Player);
            Assert.True(GridEdge);
        }
        [Fact]
        public void TestGridEdgeFacingEast()
        {
            Board board = new Board(1, 1);
            board.Player.Turn("left");
            bool GridEdge = RepeatUntilFunctions.GridEdge(board.Player);
            Assert.True(GridEdge);
        }
        [Fact]
        public void TestGridEdgeFacingWest()
        {
            Board board = new Board(1, 1);
            board.Player.Turn("right");
            bool GridEdge = RepeatUntilFunctions.GridEdge(board.Player);
            Assert.True(GridEdge);
        }
    }
}

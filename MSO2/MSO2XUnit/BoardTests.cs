using System;
using MSO2;
using Xunit;
using Xunit.Abstractions;

namespace MSO2XUnit
{
    public class BoardTests
    {
        [Fact]
        public void OutOfLowerBounds()
        {
            Position newPosition = Board.BoardBounds(new Position(-1, -1));
            Assert.Equal(newPosition, new Position(0, 0));
        }

        [Fact]
        public void testPrintedBoard()
        {
            Board board = new Board(10, 10);
            board.printBoard();
            Assert.Equal(board, board);
        }
    }
}

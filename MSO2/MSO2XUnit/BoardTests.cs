using System;
using MSO2;
using Xunit;
using Xunit.Abstractions;

namespace MSO2XUnit
{
    public class BoardTests
    {
        private readonly ITestOutputHelper output;

        public BoardTests(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void OutOfLowerBounds()
        {
            (int, int) newPosition = Board.BoardBounds((-1, -1));
            Assert.Equal(newPosition, (0, 0));
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

using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class BoardTests
    {
        [Fact]
        public void OutOfLowerBounds()
        {
            (int, int) newPosition = Board.BoardBounds((-1, -1));
            Assert.Equal(newPosition, (0, 0));
        }
    }
}

using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class PositionTests
    {
        [Fact]
        public void NextPositionTestSouth()
        {
            Board board = new(10, 10, 5, 5);
            Position newPosition = board.Player.Position.GetNextPosition(Creature.Facing.South);
            Assert.Equal(new Position(5, 6), newPosition);
        }

        [Fact]
        public void NextPositionTestEast()
        {
            Board board = new(10, 10, 5, 5);
            Position newPosition = board.Player.Position.GetNextPosition(Creature.Facing.East);
            Assert.Equal(new Position(6, 5), newPosition);
        }

        [Fact]
        public void NextPositionTestWest()
        {
            Board board = new(10, 10, 5, 5);
            Position newPosition = board.Player.Position.GetNextPosition(Creature.Facing.West);
            Assert.Equal(new Position(4, 5), newPosition);
        }

        [Fact]

        public void NextPositionTestNorth()
        {
            Board board = new(10, 10, 5, 5);
            Position newPosition = board.Player.Position.GetNextPosition(Creature.Facing.North);
            Assert.Equal(new Position(5, 4), newPosition);
        }
    }
}

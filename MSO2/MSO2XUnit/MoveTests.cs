using System;
using System.Text;
using Xunit;
using MSO2;


namespace MSO2XUnit
{
    public class MoveTests
    {
        [Fact]
        public void RepeatUntilTest()
        {
            Board boardGrid = new(10, 10);

            List<ICommand> commandsGridedge = CommandParser.Parse(new string[]{ "repeatuntil gridedge", "    move 1" });
            boardGrid.PlayBoard(commandsGridedge);

            Board boardWall = new(10, 10);

            List<ICommand> commandsWallahead = CommandParser.Parse(new string[] { "repeatuntil wallahead", "    move 1" });
            boardWall.PlayBoard(commandsWallahead);

            Assert.Equal(boardWall.Player.Position, boardGrid.Player.Position);
        }

        [Fact]
        public void RepeatTest()
        {
            Board board = new(10, 10);

            List<ICommand> CommandsWithoutRepeat = CommandParser.Parse(TestCommands.TestMoveNoRepeat);
            List<ICommand> CommandsWithRepeat = CommandParser.Parse(TestCommands.TestMoveWithRepeat);

            string resultWithoutRepeat = board.PlayBoard(CommandsWithoutRepeat);
            
            board = new Board(10, 10);

            string resultWithRepeat = board.PlayBoard(CommandsWithRepeat);

            Assert.Equal(resultWithRepeat, resultWithoutRepeat);
        }

        [Fact]
        public void MoveTest()
        {
            Board board = new(10, 10);

            List<ICommand> Commands = CommandParser.Parse(TestCommands.TestMoveNoRepeat);

            string result = board.PlayBoard(Commands);

            string[] words = result.Split(FacingTests.separator, StringSplitOptions.RemoveEmptyEntries);
            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 6)).ToArray())[1..];


            Assert.Equal("End state (0, 0) facing East", lastWords);
        }

        [Fact]
        public void ToStringTest()
        {
            List<ICommand> Commands = CommandParser.Parse(TestCommands.TestMoveWithRepeatUntil);

            StringBuilder sb = new ();
            foreach (ICommand command in Commands)
            {
                sb.Append($"{command.ToString()}, ");
            }

            string result = "Repeat 4 times: [Repeat until: [Move 1], Turn left], ";

            Assert.Equal(result, sb.ToString());
        }

        [Fact]
        public void TestPositionNotEqual()
        {
            Position pos1 = new Position(0, 1);
            Position pos2 = new Position(0, 0);
            Assert.NotEqual(pos1, pos2);
        }

        [Theory]
        [InlineData("Move 100")]
        [InlineData("Turn left,Move 100")]
        [InlineData("Turn right,Move 100")]
        [InlineData("Turn right,Turn right,Move 100")]
        public void RanIntoWall(string commands)
        {
            List<ICommand> commandList = CommandParser.Parse(commands.Split(','));
            Board board = new Board(10, 10);

            board.PlayBoard(commandList);

            bool result = board.Player.RanInWall;
            Assert.True(result);
        }
    }
}
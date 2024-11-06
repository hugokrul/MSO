using System;
using System.Text;
using Xunit;
using MSO2;


namespace MSO2XUnit
{
    public class MoveTests
    {

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
            List<ICommand> Commands = CommandParser.Parse(TestCommands.TestMoveWithRepeat);

            StringBuilder sb = new StringBuilder();
            foreach (ICommand command in Commands)
            {
                sb.Append($"{command.ToString()}, ");
            }

            string result = "Turn left, Repeat 4 times: Move 10, Turn right, ";

            Assert.Equal(result, sb.ToString());
        }
    }
}
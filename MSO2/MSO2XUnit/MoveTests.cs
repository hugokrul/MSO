using System;
using Xunit;
using MSO2;


namespace MSO2XUnit
{
    public class MoveTests
    {

        [Fact]
        public void RepeatTest()
        {
            Board board = new Board(10, 10);

            List<ICommand> CommandsWithoutRepeat = CommandParser.Parse(File.ReadAllText(@"..\..\..\moveCommands\testMoveNoRepeat.txt").Split('\n'));
            List<ICommand> CommandsWithRepeat = CommandParser.Parse(File.ReadAllText(@"..\..\..\moveCommands\testMoveWithRepeat.txt").Split('\n'));

            string resultWithoutRepeat = board.PlayBoard(CommandsWithoutRepeat);
            
            board = new Board(10, 10);

            string resultWithRepeat = board.PlayBoard(CommandsWithRepeat);

            Assert.Equal(resultWithRepeat, resultWithoutRepeat);
        }

        [Fact]
        public void MoveTest()
        {
            Board board = new Board(10, 10);

            List<ICommand> Commands = CommandParser.Parse(File.ReadAllText(@"..\..\..\moveCommands\testMoveNoRepeat.txt").Split('\n'));

            string result = board.PlayBoard(Commands);

            string[] words = result.Split(FacingTests.separator, StringSplitOptions.RemoveEmptyEntries);
            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 6)).ToArray())[1..];


            Assert.Equal("End state (0, 0) facing East", lastWords);
        }
    }
}
using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class FacingTests
    {
        public static readonly char[] separator = [' '];
        [Fact]
        public void UnchangedFacing()
        {
            Board board = new(10, 10);

            List<ICommand> Commands = [];

            string result = board.PlayBoard(Commands);

            string[] words = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 2)).ToArray());


            Assert.Equal("facing South", lastWords);
        }


        [Fact]
        public void FacingMoveInSquare()
        {
            Board board = new(10, 10);
            List<ICommand> Commands = CommandParser.Parse(TestCommands.TestFacingSquare);

            string result = board.PlayBoard(Commands);

            string[] words = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 2)).ToArray());


            Assert.Equal("facing East", lastWords);
        }
    }
}

//using System;
//using MSO2;
//using Xunit;

//namespace MSO2XUnit
//{
//    public class FacingTests
//    {
//        [Fact]
//        public void UnchangedFacing()
//        {
//            Board.DeleteInstance();
//            Board board = Board.GetInstance();

//            List<ICommand> Commands = new List<ICommand>() { };

//            string result = board.PlayBoard(Commands);

//            string[] words = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 2)).ToArray());


//            Assert.Equal("facing South", lastWords);
//        }

//        [Fact]
//        public void FacingMoveInSquare()
//        {
//            Board.DeleteInstance();
//            Board board = Board.GetInstance();

//            List<ICommand> Commands = CommandParser.Parse(File.ReadAllText(@"..\..\..\moveCommands\testFacingSquare.txt").Split('\n'));

//            string result = board.PlayBoard(Commands);
//            Board.DeleteInstance();

//            string[] words = result.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            string lastWords = string.Join(" ", words.Skip(Math.Max(0, words.Length - 2)).ToArray());


//            Assert.Equal("facing East", lastWords);
//        }
//    }
//}

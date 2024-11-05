using System;
using MSO2;
using MSO3;
using Xunit;
using System.Windows.Forms;

namespace MSO2XUnit
{
    public class MSO3Tests
    {

        [Theory]
        [InlineData("Hard")]
        [InlineData("Advanced")]
        [InlineData("Basic")]
        public void chosenProgramTest(string choice)
        {
            Sandbox sandbox = Sandbox.GetInstance();
            List<string> result = sandbox.ChosenProgram(choice);

            int index = 0;
            switch (choice)
            {
                case "Basic":
                    index = 0;
                    break;
                case "Hard":
                    index = 1;
                    break;
                case "Advanced":
                    index = 2;
                    break;
            }

            List<string> expected = MSO2.Program.AvailablePrograms[index].Skip(1).ToList().ConvertAll(c => c.ToLower());

            Assert.Equal(expected, result);
            Sandbox.DeleteInstance();
        }

        [Fact]
        public void startPositionTestEmptyBoard()
        {
            string[,] emptyBoard = { { } };
            (int, int) expected = (-1, -1);
            (int, int) result = Shape.FindStartPosition(emptyBoard);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void startPositionTestNoStartBoard()
        {
            string[,] noStartPositionBoard = 
            {
                { "+", "+", "+", "+", "+" }, 
                { "+", "+", "+", "+", "+" }, 
                { "+", "+", "+", "+", "+" }, 
                { "+", "+", "+", "+", "+" }, 
                { "+", "+", "+", "+", "+" }
            };
            (int, int) expected = (-1, -1);
            (int, int) result = Shape.FindStartPosition(noStartPositionBoard);
            Assert.Equal(expected, result);
        }

        public void startPositionTestMiddleBoard()
        {
            string[,] middleStartPositionBoard =
            {
                { "+", "+", "+", "+", "+" },
                { "+", "+", "+", "+", "+" },
                { "+", "+", "s", "+", "+" },
                { "+", "+", "+", "+", "+" },
                { "+", "+", "+", "+", "+" }
            };
            (int, int) expected = (2, 2);
            (int, int) result = Shape.FindStartPosition(middleStartPositionBoard);
            Assert.Equal(expected, result);
        }
    }
}
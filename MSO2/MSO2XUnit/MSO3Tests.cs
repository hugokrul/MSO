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
        public void ChosenProgramTest(string choice)
        {
            Sandbox sandbox = Sandbox.GetInstance();
            List<string> result = sandbox.ChosenProgram(choice).ConvertAll(c => c.ToLower());

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
        public void StartPositionTestEmptyBoard()
        {
            string[,] emptyBoard = { { } };
            (int, int) expected = (-1, -1);
            (int, int) result = Shape.FindStartPosition(emptyBoard);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StartPositionTestNoStartBoard()
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

        [Fact]
        public void StartPositionTestMiddleBoard()
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
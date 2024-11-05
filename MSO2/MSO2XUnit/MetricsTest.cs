using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class MetricsTest
    {
        readonly string[] input = { "Repeat 2 times", "    Turn left", "    Repeat 4 times", "        Turn left", "    Move 1", "    Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left" };

        [Fact]
        public void TestNumberOfCommands()
        {
            int expected = input.Length;
            CalculateMetrics.calculateMetrics(input);

            int result = CalculateMetrics.NumberOfCommands;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestNumberOfRepeats()
        {
            int expected = 4;
            CalculateMetrics.calculateMetrics(input);
            int result = CalculateMetrics.NumberOfRepeat;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestNestingLevel()
        {
            int expected = 2;
            CalculateMetrics.calculateMetrics(input);
            int result = CalculateMetrics.NestingLevel;
            Assert.Equal(expected, result);
        }
    }
}

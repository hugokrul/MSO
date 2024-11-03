//using System;
//using MSO2;
//using Xunit;

//namespace MSO2XUnit
//{
//    public class MetricsTest
//    {
//        string[] input = { "Repeat 2 times", "    Turn left", "    Repeat 4 times", "        Turn left", "    Move 1", "    Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left" };
        
//        [Fact]
//        public void TestNumberOfCommands()
//        {
//            List<ICommand> commands = CommandParser.Parse(input);
//            CalculateMetrics.calculateMetrics(input);
//            Assert.Equal(commands.Count, CalculateMetrics.numberOfCommands);
//        }

//        [Fact]
//        public void TestNumberOfRepeats()
//        {
//            CalculateMetrics.calculateMetrics(input);
//            Assert.Equal(4, CalculateMetrics.numberOfRepeat);
//        }

//        [Fact]
//        public void TestNestingLevel()
//        {
//            CalculateMetrics.calculateMetrics(input);
//            Assert.Equal(2, CalculateMetrics.nestingLevel);
//        }
//    }
//}

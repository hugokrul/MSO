using System;
using MSO2;
using Xunit;

namespace MSO2XUnit
{
    public class ParserTests
    {
        [Fact]
        public void TestParseWithRepeat()
        {
            string[] input = { "Repeat 2 times", "    Turn left", "    Repeat 4 times", "        Turn left", "    Move 1", "    Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left" };
            List<ICommand> commands = CommandParser.Parse(input);
            Assert.True(input.Length <= commands.Count);
        }

        [Fact]
        public void TestParseNoRepeat()
        {
            string[] input = { "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1" };
            List<ICommand> commands = CommandParser.Parse(input);
            Assert.Equal(input.Length,  commands.Count);
        }
    }
}

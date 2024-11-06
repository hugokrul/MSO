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
            Assert.True(input.Length >= commands.Count);
        }

        [Fact]
        public void TestParseNoRepeat()
        {
            string[] input = { "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1" };
            List<ICommand> commands = CommandParser.Parse(input);
            Assert.Equal(input.Length, commands.Count);
        }

        [Fact]
        public void TestUnrecognisedCommand()
        {
            string[] input = { "unrecognisable Command", "Move unrecognisable", "turn kd", "RepeatUntil unrecognisable", "Repeat unrecognisable", "Repeat 2 times", "    Turn left", "    Repeat 4 times", "        Turn left", "    Move 1", "    Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left" };
            CalculateMetrics.calculateMetrics(input);
            Assert.Equal(input.Length, CalculateMetrics.NumberOfCommands);
        }

        [Fact] 
        public void TestWrongIndent()
        {
            string[] input = { "    move 1" };
            List<ICommand> commands = CommandParser.Parse(input);
            Assert.Equal(commands, []);
        }

        [Fact] 
        public void TestPredicateBadInput()
        {
            Func<Creature, bool>? predicateResult = CommandParser.WhatPredicate("");
            Assert.Null(predicateResult);
        }

        [Fact]
        public void TestPredicateWallAhead()
        {
            Func<Creature, bool>? predicateResult = CommandParser.WhatPredicate("wallahead");
            Func<Creature, bool> expected = RepeatUntilFunctions.WallAhead;
            Assert.Equal(expected, predicateResult);
        }

        [Fact]
        public void TestPredicateGridEdge()
        {
            Func<Creature, bool>? predicateResult = CommandParser.WhatPredicate("gridedge");
            Func<Creature, bool> expected = RepeatUntilFunctions.GridEdge;
            Assert.Equal(expected, predicateResult);
        }
    }
}

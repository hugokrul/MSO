using System;
using System.Collections.Generic;

namespace MSO2
{
    public static class CalculateMetrics
    {
        // Metrics properties for tracking command details.
        public static int NumberOfCommands { get; private set; }
        public static int NestingLevel { get; private set; }
        public static int NumberOfRepeat { get; private set; }

        // Calculates various metrics based on the given list of commands.
        public static void calculateMetrics(string[] commands)
        {
            NumberOfCommands = calculateNumberOfCommands(commands);
            NestingLevel = calculateNestingLevel(commands);
            NumberOfRepeat = calculateNumberOfRepeats(commands);
        }

        // Returns the total number of commands.
        private static int calculateNumberOfCommands(string[] commands)
        {
            return commands.Length;
        }

        // Calculates the maximum indent ("        Move 1") means there are 2 repeat commands, so a nesting level of 2.
        private static int calculateNestingLevel(string[] commands)
        {
            int maxIndent = 0;
            foreach (string command in commands)
            {
                int currentIndent = CommandParser.GetIndentLevel(command);
                maxIndent = Math.Max(maxIndent, currentIndent);
            }
            return maxIndent;
        }

        // Counts how many 'RepeatCommand' commands are in the list.
        private static int calculateNumberOfRepeats(string[] commands)
        {
            int count = 0;
            foreach (string command in commands)
            {
                if (command.Trim().Split()[0].ToLower() == "repeat" || command.Trim().Split()[0].ToLower() == "repeatuntil") count++;
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;

namespace MSO2
{
    public class CalculateMetrics
    {
        // Metrics properties for tracking command details.
        public static int numberOfCommands { get; private set; }
        public static int nestingLevel { get; private set; }
        public static int numberOfRepeat { get; private set; }

        // Calculates various metrics based on the given list of commands.
        public static void calculateMetrics(string[] commands)
        {
            numberOfCommands = calculateNumberOfCommands(commands);
            nestingLevel = calculateNestingLevel(commands);
            numberOfRepeat = calculateNumberOfRepeats(commands);
        }

        // Returns the total number of commands.
        private static int calculateNumberOfCommands(string[] commands)
        {
            List<ICommand> parsedCommands = CommandParser.Parse(commands);
            return parsedCommands.Count;
        }

        // Calculates the maximum indent ("        Move 1") means there are 2 repeat commands, so a nesting level of 2.
        private static int calculateNestingLevel(string[] commands)
        {
            int maxIndent = 0;
            foreach (string command in commands)
            {
                int currentIndent = command.Length - command.TrimStart().Length;
                maxIndent = Math.Max(maxIndent, currentIndent);
            }
            return maxIndent / 4;
        }

        // Counts how many 'RepeatCommand' commands are in the list.
        private static int calculateNumberOfRepeats(string[] commands)
        {
            int count = 0;
            foreach (string command in commands)
            {
                if (command.Trim().Split()[0] == "Repeat") count++;
            }
            return count;
        }
    }
}

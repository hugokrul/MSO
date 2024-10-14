using System;
using System.Collections.Generic;

namespace MSO2
{
    internal class CalculateMetrics
    {
        // Metrics properties for tracking command details.
        public static int numberOfCommands { get; private set; }
        public static int nestingLevel { get; private set; }
        public static int numberOfRepeat { get; private set; }

        // Calculates various metrics based on the given list of commands.
        public static void calculateMetrics(List<ICommand> commands)
        {
            numberOfCommands = calculateNumberOfCommands(commands);
            nestingLevel = calculateNestingLevel(commands);
            numberOfRepeat = calculateNumberOfRepeats(commands);
        }

        // Returns the total number of commands.
        private static int calculateNumberOfCommands(List<ICommand> commands)
        {
            return commands.Count;
        }

        // Placeholder for calculating the nesting level (currently returns 0).
        private static int calculateNestingLevel(List<ICommand> commands)
        {
            return 0;
        }

        // Counts how many 'RepeatCommand' commands are in the list.
        private static int calculateNumberOfRepeats(List<ICommand> commands)
        {
            int count = 0;
            foreach (var command in commands)
            {
                if (command.GetType() == typeof(RepeatCommand)) count++;
            }
            return count;
        }
    }
}

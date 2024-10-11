using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal class CalculateMetrics
    {
        public static int numberOfCommands { get; private set; }
        public static int nestingLevel { get; private set; }
        public static int numberOfRepeat { get; private set; }


        public static void calculateMetrics(List<ICommand> commands)
        {
            numberOfCommands = calculateNumberOfCommands(commands);
            nestingLevel = calculateNestingLevel(commands);
            numberOfRepeat = calculateNumberOfRepeats(commands);
        }

        private static int calculateNumberOfCommands(List<ICommand> commands)
        {
            return commands.Count;
        }

        private static int calculateNestingLevel(List<ICommand> commands)
        {
            return 0;
        }

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

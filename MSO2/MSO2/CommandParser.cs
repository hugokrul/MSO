using MSO2;
using System;
using System.Collections.Generic;

namespace MSO2
{
    public static class CommandParser
    {
        // Parses command strings and returns a list of ICommand objects.
        public static List<ICommand> Parse(string[] commandStrings, int startIndex = 0, int endIndex = -1)
        {
            List<ICommand> commandResult = [];
            int i = startIndex;
            commandStrings = [.. commandStrings.ToList().ConvertAll(c => c.ToLower())];

            while (i < (endIndex == -1 ? commandStrings.Length : endIndex))
            {
                string line = commandStrings[i].Trim();

                if (line.StartsWith("repeat"))
                {
                    i = HandleRepeatCommand(commandStrings, commandResult, i);
                }
                else if (line.StartsWith("move"))
                {
                    // Create a MoveCommand and add it to the result list.
                    AddMoveCommand(commandResult, line);
                    i++;
                }
                else if (line.StartsWith("turn"))
                {
                    // Create a TurnCommand and add it to the result list.
                    AddTurnCommand(commandResult, line);
                    i++;
                }
                else
                {
                    i++;  // Skip unrecognized lines.
                }
            }

            return commandResult;  // Return the list of commands.
        }
        private static int HandleRepeatCommand(string[] commandStrings, List<ICommand> commandResult, int index)
        {
            string line = commandStrings[index];
            string[] parts = line.Split(' ');
            int repeatCount;

            if (!int.TryParse(parts.ElementAtOrDefault(1), out repeatCount))
                return index + 1;  // Skip if repeat count is invalid.

            int endIndex = FindBlockEnd(commandStrings, index + 1);
            if (endIndex <= index)
                return index + 1;  // No valid block found, skip this line.

            List<ICommand> blockActions = Parse(commandStrings, index + 1, endIndex);
            commandResult.Add(new RepeatCommand(blockActions, repeatCount));
            return endIndex;
        }

        private static int FindBlockEnd(string[] commandStrings, int startIndex)
        {
            int i = startIndex;
            while (i < commandStrings.Length && commandStrings[i].StartsWith(' '))
                i++;
            return i;
        }

        private static void AddMoveCommand(List<ICommand> commandResult, string line)
        {
            if (int.TryParse(line.Split(' ').ElementAtOrDefault(1), out int steps))
            {
                commandResult.Add(new MoveCommand(steps));
            }
        }

        private static void AddTurnCommand(List<ICommand> commandResult, string line)
        {
            string direction = line.Split(' ').ElementAtOrDefault(1);
            if (direction != null)
            {
                commandResult.Add(new TurnCommand(direction));
            }
        }
    }
}

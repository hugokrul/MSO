using MSO2;
using System;
using System.Collections.Generic;

namespace MSO2
{
    public class CommandParser
    {
        // Parses command strings and returns a list of ICommand objects.
        public static List<ICommand> Parse(string[] commandStrings, int startIndex = 0, int endIndex = -1)
        {
            List<ICommand> commandResult = new List<ICommand>();
            int i = startIndex;

            while (i < (endIndex == -1 ? commandStrings.Length : endIndex))
            {
                string line = commandStrings[i].Trim();

                if (line.StartsWith("Repeat"))
                {
                    List<ICommand> range = new List<ICommand>();

                    // Parse repeat count and find block of commands to repeat.
                    string[] parts = line.Split(' ');
                    int repeatCount = int.Parse(parts[1]);

                    int j = i + 1;
                    while (j < commandStrings.Length && commandStrings[j].StartsWith(" ")) j++;

                    // Recursivly iterates through the commandStrings to add the commands from the repeat command to the commandResults
                    List<ICommand> blockActions = Parse(commandStrings, i + 1, j);

                    // Add repeated commands to the result list.
                    for (int k = 0; k < repeatCount; k++)
                    {
                        range.AddRange(blockActions);
                    }

                    commandResult.Add(new RepeatCommand(range, repeatCount));

                    i = j;  // Move index to the end of the block.
                }
                else if (line.StartsWith("Move"))
                {
                    // Create a MoveCommand and add it to the result list.
                    commandResult.Add(new MoveCommand(int.Parse(line.Split(' ')[1])));
                    i++;
                }
                else if (line.StartsWith("Turn"))
                {
                    // Create a TurnCommand and add it to the result list.
                    commandResult.Add(new TurnCommand(line.Split(' ')[1]));
                    i++;
                }
                else
                {
                    i++;  // Skip unrecognized lines.
                }
            }

            return commandResult;  // Return the list of commands.
        }
    }
}

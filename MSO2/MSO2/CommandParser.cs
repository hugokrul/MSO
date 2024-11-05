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

            while (i < (endIndex == -1 ? commandStrings.Length : endIndex))
            {
                string line = commandStrings[i].Trim();

                if (line.StartsWith("repeat"))
                {
                    int j = i + 1;
                    try
                    {
                        // Parse repeat count and find block of commands to repeat.
                        string[] parts = line.Split(' ');
                        int repeatCount = int.Parse(parts[1]);

                        while (j < commandStrings.Length && commandStrings[j].StartsWith(' ')) j++;

                        // Recursivly iterates through the commandStrings to add the commands from the repeat command to the commandResults
                        List<ICommand> blockActions = Parse(commandStrings, i + 1, j);

                        commandResult.Add(new RepeatCommand(blockActions, repeatCount)); 
                    }
                    catch { /* do nothing */ }

                    i = j;  // Move index to the end of the block.
                }
                else if (line.StartsWith("move"))
                {
                    // Create a MoveCommand and add it to the result list.
                    try { commandResult.Add(new MoveCommand(int.Parse(line.Split(' ')[1]))); }
                    catch { /* do nothing */ }
                    i++;
                }
                else if (line.StartsWith("turn"))
                {
                    // Create a TurnCommand and add it to the result list.
                    try { commandResult.Add(new TurnCommand(line.Split(' ')[1])); }
                    catch { /* do nothing */ }
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

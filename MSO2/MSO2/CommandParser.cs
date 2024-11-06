using MSO2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                if (line.StartsWith("repeatuntil"))
                {
                    int j = i + 1;
                    string[] parts = line.Split(' ');

                    Func<Creature, bool>? _predicate = WhatPredicate(parts[1]);

                    if (_predicate == null)
                    {
                        i++;
                        continue;
                    }

                    j = FindBlockEnd(commandStrings, j);

                    List<ICommand> blockActions = Parse(commandStrings, i + 1, j);
                    commandResult.Add(new RepeatUntilCommand(blockActions, _predicate));
                    i = j;
                }
                else if (line.StartsWith("repeat"))
                {
                    int j = i + 1;
                    // Parse repeat count and find block of commands to repeat.
                    string[] parts = line.Split(' ');

                    if (!int.TryParse(parts.ElementAtOrDefault(1), out int repeatCount))
                    {
                        i++;  // Skip if repeat count is invalid.
                        continue;
                    }

                    j = FindBlockEnd(commandStrings, j);

                    // Recursivly iterates through the commandStrings to add the commands from the repeat command to the commandResults
                    List<ICommand> blockActions = Parse(commandStrings, i + 1, j);

                    commandResult.Add(new RepeatCommand(blockActions, repeatCount)); 
                    
                    i = j;  // Move index to the end of the block.
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

        private static Func<Creature, bool>? WhatPredicate(string? input)
        {
            return (input?.Trim()) switch
            {
                "wallahead" => RepeatUntilFunctions.WallAhead,
                "gridedge" => RepeatUntilFunctions.GridEdge,
                _ => null,
            };
        }

        private static int FindBlockEnd(string[] commandStrings, int startIndex)
        {
            //int i = startIndex;
            //while (i < commandStrings.Length && commandStrings[i].StartsWith("    "))
            //{
            //    i++;
            //}
            //return i;

            int i = startIndex;
            int initialIndentationLevel = commandStrings[startIndex].TakeWhile(char.IsWhiteSpace).Count();

            while (i < commandStrings.Length)
            {
                // Calculate the indentation level of the current line
                int currentIndentationLevel = commandStrings[i].TakeWhile(char.IsWhiteSpace).Count();

                // If we find a line with less indentation, it means the block has ended
                if (currentIndentationLevel < initialIndentationLevel || i == commandStrings.Length)
                {
                    break;
                }

                Console.WriteLine(currentIndentationLevel);

                i++;
            }

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
            string? direction = line.Split(' ').ElementAtOrDefault(1);
            if (direction != null)
            {
                commandResult.Add(new TurnCommand(direction));
            }
        }
    }
}

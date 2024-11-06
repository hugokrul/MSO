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
        public static List<ICommand> ParseCommandBlock(string[] commands, ref int index, int indentLevel)
        {
            List<ICommand> commandList = [];

            while (index < commands.Length)
            {
                string command = commands[index];
                int currentIndent = GetIndentLevel(command);

                if (currentIndent < indentLevel)
                {
                    break;
                }

                if (currentIndent > indentLevel)
                {
                    index++;
                    commandList.AddRange(ParseCommandBlock(commands, ref index, currentIndent));
                }
                else
                {
                    command = command.Trim();

                    if (command.StartsWith("repeatuntil"))
                    {
                        Func<Creature, bool>? _predicate = WhatPredicate(command.Split(' ').ElementAtOrDefault(1));

                        if (_predicate == null)
                        {
                            index++;
                            continue;
                        }
                        index++;
                        List<ICommand> nestedCommands = ParseCommandBlock(commands, ref index, currentIndent + 1);
                        commandList.Add(new RepeatUntilCommand(nestedCommands, _predicate));
                    }
                    else if (command.StartsWith("repeat"))
                    {
                        if (!int.TryParse(command.Split(' ').ElementAtOrDefault(1), out int repeatCount))
                        {
                            index++;  // Skip if repeat count is invalid.
                            continue;
                        }
                        index++;
                        List<ICommand> nestedCommands = ParseCommandBlock(commands, ref index, currentIndent + 1);
                        commandList.Add(new RepeatCommand(nestedCommands, repeatCount));
                    }
                    else if (command.StartsWith("move"))
                    {
                        commandList = AddMoveCommand(commandList, command);
                        index++;
                    }
                    else if (command.StartsWith("turn"))
                    {
                        commandList = AddTurnCommand(commandList, command);
                        index++;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return commandList;

        }

        // Parses command strings and returns a list of ICommand objects.
        public static List<ICommand> Parse(string[] commandStrings)
        {
            int index = 0;
            return ParseCommandBlock([.. commandStrings.ToList().ConvertAll(c => c.ToLower())], ref index, 0);
        }

        private static int GetIndentLevel(string command)
        {
            int indent = 0;
            while (indent < command.Length && command[indent] == ' ')
                indent++;
            return indent / 4; // assuming 4 spaces per indentation level
        }

        public static Func<Creature, bool>? WhatPredicate(string? input)
        {
            return (input?.Trim()) switch
            {
                "wallahead" => RepeatUntilFunctions.WallAhead,
                "gridedge" => RepeatUntilFunctions.GridEdge,
                _ => null,
            };
        }

        private static List<ICommand> AddMoveCommand(List<ICommand> commandList, string line)
        {
            if (int.TryParse(line.Split(' ').ElementAtOrDefault(1), out int steps))
            {
                commandList.Add(new MoveCommand(steps));
            }

            return commandList;
        }

        private static List<ICommand> AddTurnCommand(List<ICommand> commandList, string line)
        {
            string? direction = line.Split(' ').ElementAtOrDefault(1);
            if (direction != null)
            {
                commandList.Add(new TurnCommand(direction));
            }

            return commandList;
        }
    }
}

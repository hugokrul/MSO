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
            // The commandlist of the commands with an indentlevel 4 higher then the command itself.
            List<ICommand> commandList = [];

            // Go through all the commands
            while (index < commands.Length)
            {
                string command = commands[index];
                int currentIndent = GetIndentLevel(command);

                // If the currentIndent is smaller then the indentlevel of the command executing this function, you do not need to add that command to the commandList
                if (currentIndent < indentLevel)
                {
                    break;
                }

                // If it is bigger, you need to go through the next set of commands recursively.
                if (currentIndent > indentLevel)
                {
                    index++;
                    commandList.AddRange(ParseCommandBlock(commands, ref index, currentIndent));
                }
                else
                {
                    command = command.Trim();

                    // Adds the repeatuntil command to the commandList
                    if (command.StartsWith("repeatuntil"))
                    {
                        // elementAtOrDefault ensures that edgecases are handled correctly
                        Func<Creature, bool>? _predicate = RepeatUntilFunctions.WhatPredicate(command.Split(' ').ElementAtOrDefault(1));

                        // If it encountered an edge case, you need to skip the functions because the syntax of the program is wrong.
                        // It also skips all the "child" commands of the repeat commands
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
                        // If you cannot parse the amount of times a list have to be repeated, you go to the next commands
                        // It also skips all the "child commands of the repeat commands.
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
        // To make sure the recursion has a base case, the parse command is delegated to a different command.
        public static List<ICommand> Parse(string[] commandStrings)
        {
            int index = 0;
            return ParseCommandBlock([.. commandStrings.ToList().ConvertAll(c => c.ToLower())], ref index, 0);
        }

        // Returns the indentLevel of a command. i.e, ("        Move 1") is an indent of 2.
        public static int GetIndentLevel(string command)
        {
            int indent = 0;
            while (indent < command.Length && command[indent] == ' ')
                indent++;
            return indent / 4; // assuming 4 spaces per indentation level
        }

        // adds a move command to a commandList
        // also handles edge cases
        private static List<ICommand> AddMoveCommand(List<ICommand> commandList, string line)
        {
            if (int.TryParse(line.Split(' ').ElementAtOrDefault(1), out int steps))
            {
                commandList.Add(new MoveCommand(steps));
            }

            return commandList;
        }

        // adds a turn command to a commandList
        // also handles edgecases
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

using MSO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal class CommandParser
    {
        public static List<ICommand> Parse(string[] commandStrings, int startIndex = 0, int endIndex = -1)
        {
            List<ICommand> commandResult = new List<ICommand>();
            int i = startIndex;

            while (i < (endIndex == -1 ? commandStrings.Length : endIndex))
            {
                string line = commandStrings[i].Trim();

                if (line.StartsWith("Repeat"))
                {
                    string[] parts = line.Split(' ');
                    int repeatCount = int.Parse(parts[1]);

                    int j = i + 1;
                    while (j < commandStrings.Length && commandStrings[j].StartsWith(" ")) j++;

                    List<ICommand> blockActions = Parse(commandStrings, i + 1, j);

                    for (int k = 0; k < repeatCount; k++)
                    {
                        commandResult.AddRange(blockActions);
                    }

                    i = j;
                }
                else if (line.StartsWith("Move"))
                {
                    commandResult.Add(new MoveCommand(int.Parse(line.Split(' ')[1])));
                    i++;
                }
                else if (line.StartsWith("Turn"))
                {
                    commandResult.Add(new TurnCommand(line.Split(' ')[1]));
                    i++;
                }
                else i++;
            }

            return commandResult;
        }
    }
}

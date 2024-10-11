using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Input;

namespace MSO2
{
    internal class Program
    {
        public string Name;

        static void Main(string[] args)
        {
            Board board = Board.GetInstance();

            string[] log = File.ReadAllText(@"..\..\..\Hard.txt").Split('\n');
            string[] Basic = { "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Turn left", "Move 5", "Turn left"};
            string[] Advanced = { "Repeat 2 times", "    Turn left", "    Move 1", "     Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left"};

            List<ICommand> commandList = CommandParser.Parse(log);

            board.PlayBoard(commandList);
        }
    }
}
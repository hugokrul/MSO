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

            string[] log = File.ReadAllText(@"C:\Users\hugok\Documents\code\MSO\MSO2\MSO2\MSO2\Hard.txt").Split('\n');

            List<ICommand> commandList = CommandParser.Parse(log);

            board.PlayBoard(commandList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;

namespace MSO2
{
    internal class Program
    {
        public string Name;

        static List<string[]> availablePrograms;

        static void Main(string[] args)
        {
            GetBoardInstance();
            ReadFiles();

            string[] chosenprogram = ChooseProgram();
            List<ICommand> commandList = CommandParser.Parse(chosenprogram);

            board.PlayBoard(commandList);

            // Calculate metrics for the commands.
            CalculateMetrics.calculateMetrics();
        }

        // Retrieves the singleton instance of the board.
        static void GetBoardInstance()
        {
            Board.GetInstance();
        }

        // Reads programs from hard-coded arrays or text file.
        static void ReadFiles()
        {
            string[] log = File.ReadAllText(@"..\..\..\Hard.txt").Split('\n');
            string[] Basic = { "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Turn left", "Turn left", "Move 5", "Turn left" };
            string[] Advanced = { "Repeat 2 times", "    Turn left", "    Move 1", "     Turn right", "    Move 1", "Repeat 2 times", "    Turn left", "    Move 1", "Turn right", "Move 1", "Turn left", "Move 1", "Turn right", "Move 1", "Repeat 2 times", "    Turn left", "Move 5", "Turn left" };
            string[] Hard = { "Repeat 2 times", "    Move 2" };

            availablePrograms = new List<string[]>
            {
                Basic,   // Add Basic commands
                Hard,     // Add Hard commands
                Advanced, // Add Advanced commands
                log     // Add the log commands
            };
        }

        static string[] ChooseProgram()
        {
            // Choose program
            Console.WriteLine("Choose program: basic, hard, advanced or import");
            string choice = Console.ReadLine().ToLower(); // Read user input

            string[] program;

            switch (choice)
            {
                case "basic":
                    program = availablePrograms[0];
                    break;
                case "hard":
                    program = availablePrograms[1];
                    break;
                case "advanced":
                    program = availablePrograms[2];
                    break;
                case "import":
                    program = availablePrograms[3];
                    break;
                case default:
                    Console.WriteLine("Program not detected, please try again.");
                    ChooseProgram();
                    break;
            }

            return program;
        }
    }
}

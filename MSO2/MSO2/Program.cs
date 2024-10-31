﻿namespace MSO2
{
    public class Program
    {
        public string Name;

        public static List<string[]> availablePrograms = new List<string[]>
        {
            // Basic program
            new string[]
            {
                "Name: BasicProgram",
                "Turn left", "Move 1", "Turn right", "Move 1",
                "Turn left", "Move 1", "Turn right", "Move 1",
                "Turn left", "Move 1", "Turn left", "Move 1",
                "Turn right", "Move 1", "Turn left", "Move 1",
                "Turn right", "Move 1", "Turn left", "Turn left",
                "Move 5", "Turn left"
            },

            // Hard program
            new string[]
            {
                "Name: HardProgram",
                "Repeat 10 times", "    Turn left", "    Move 1",
                "    Turn right", "    Move 1", "    Repeat 4 times",
                "        Turn right", "        Move 1"
            },

            // Advanced program
            new string[]
            {
                "Name: AdvancedProgram",
                "Repeat 2 times", "    Turn left", "    Move 1",
                "    Turn right", "    Move 1", "Repeat 2 times",
                "    Turn left", "    Move 1", "Turn right",
                "Move 1", "Turn left", "Move 1", "Turn right",
                "Move 1", "Repeat 2 times", "    Turn left",
                "Move 5", "Turn left"
            }
        };

        static void Main(string[] args)
        {
            string[] chosenProgram = ChooseProgram();
            if (chosenProgram == null)
            {
                Console.WriteLine("No valid program was chosen.");
                return;
            }

            List<ICommand> commandList = CommandParser.Parse(chosenProgram);
            Board board = new Board(10, 10);

            Console.WriteLine("Do you want to execute the program (e), or calculate its metrics (c)?");
            string choice = GetValidatedChoice();

            switch (choice)
            {
                case "e":
                    Console.WriteLine(board.PlayBoard(commandList));
                    break;
                case "c":
                    CalculateMetrics.calculateMetrics(chosenProgram);
                    Console.WriteLine(
                        $"Number of commands: {CalculateMetrics.numberOfCommands}\n" +
                        $"Nesting level: {CalculateMetrics.nestingLevel}\n" +
                        $"Number of Repeats: {CalculateMetrics.numberOfRepeat}");
                    break;
            }
        }

        static string[] ChooseProgram()
        {
            while (true)
            {
                Console.WriteLine("Choose program: basic, advanced, hard or import");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "basic":
                        return availablePrograms[0];
                    case "hard":
                        return availablePrograms[1];
                    case "advanced":
                        return availablePrograms[2];
                    case "import":
                        return ImportProgram();
                    default:
                        Console.WriteLine("Invalid program choice. Please try again.");
                        break;
                }
            }
        }

        static string GetValidatedChoice()
        {
            string choice = Console.ReadLine().ToLower();
            while (choice != "e" && choice != "c")
            {
                Console.WriteLine("Invalid choice, please enter 'e' to execute or 'c' to calculate metrics:");
                choice = Console.ReadLine().ToLower();
            }
            return choice;
        }

        public static string[] ImportProgram()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the full path to the file:");
                    string path = Console.ReadLine();

                    if (File.Exists(path))
                    {
                        return File.ReadAllLines(path);
                    }
                    else
                    {
                        Console.WriteLine("File not found. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while importing the program: {ex.Message}");
                    // Optionally log the exception here
                }
            }
        }
    }
}

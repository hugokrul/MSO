using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Board
    {
        public string[,] BoardArray { get; set; } // 2D array of the board (grid)
        public static int BoardHeight { get; set; } // Height of the board.
        public static int BoardWidth { get; set; } // Width of the board.

        public string Name { get; set; } = "";
        public Player Player { get; private set; }

        // Constructor to initialize board dimensions and player.
        public Board(int width, int height, int playerx = 0, int playery = 0)
        {
            BoardArray = new string[width, height]; // Initialize the board.
            BoardHeight = height;
            BoardWidth = width;
            Player = new Player((playerx, playery)); // Create a player instance.
        }

        // Executes a list of commands on the player. And returns endstate
        public string PlayBoard(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(Player);
            }

            return Player.PrintEndState(); // returns the player's final state.
        }

        // Constrains a position within the board bounds.
        public static (int, int) BoardBounds((int, int) position)
        {
            (int, int) upperBounds = (Math.Min(position.Item1, BoardWidth - 1), Math.Min(position.Item2, BoardHeight - 1));
            (int, int) lowerBounds = (Math.Max(upperBounds.Item1, 0), Math.Max(upperBounds.Item2, 0));
            return lowerBounds; // Returns the constrained position.
        }

        public void printBoard()
        {
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    Console.Write(BoardArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

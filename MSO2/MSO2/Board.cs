using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Board
    {
        public string[,] boardArray { get; set; } // 2D array of the board (grid)
        public static int boardHeight { get; set; } // Height of the board.
        public static int boardWidth { get; set; } // Width of the board.

        public Player player;

        public string? name = null;

        // Constructor to initialize board dimensions and player.
        public Board(int width, int height, int playerx = 0, int playery = 0)
        {
            boardArray = new string[width, height]; // Initialize the board.
            boardHeight = height;
            boardWidth = width;
            player = new Player((playerx, playery)); // Create a player instance.
        }

        // Executes a list of commands on the player. And returns endstate
        public string PlayBoard(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(player);
            }

            return player.PrintEndState(); // returns the player's final state.
        }

        // Constrains a position within the board bounds.
        public static (int, int) BoardBounds((int, int) position)
        {
            (int, int) upperBounds = (Math.Min(position.Item1, boardWidth - 1), Math.Min(position.Item2, boardHeight - 1));
            (int, int) lowerBounds = (Math.Max(upperBounds.Item1, 0), Math.Max(upperBounds.Item2, 0));
            return lowerBounds; // Returns the constrained position.
        }

        public void printBoard()
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Console.Write(boardArray[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

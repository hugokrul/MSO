using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Board
    {
        public static string[,]? BoardArray { get; set; } // 2D array of the board (grid)
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
            Player = new Player(new Position(playerx, playery)); // Create a player instance.
        }

        public static string[,] MakeBoardArray(string[] boardArray)
        {
            int rows = boardArray.Length;
            int cols = boardArray[0].Length;
            string[,] tempBoard = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempBoard[i, j] = boardArray[i][j].ToString();
                }
            }

            return tempBoard;
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
        public static Position BoardBounds(Position position)
        {
            Position upperBounds = new Position(Math.Min(position.X, BoardWidth - 1), Math.Min(position.Y, BoardHeight - 1));
            Position lowerBounds = new Position(Math.Max(upperBounds.X, 0), Math.Max(upperBounds.Y, 0));
            return lowerBounds; // Returns the constrained position.
        }

        public static void printBoard()
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

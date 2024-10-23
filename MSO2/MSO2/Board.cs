using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Board
    {
        private int[,] board { get; set; } // 2D array of the board (grid)
        public static int boardHeight { get; private set; } // Height of the board.
        public static int boardWidth { get; private set; } // Width of the board.

        public static Player player; 

        private static Board? _instance; // Singleton instance of the Board.

        // Gets the singleton instance of the Board. Makes sure only one board can be active
        public static Board GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }
            return _instance;
        }

        // Also deletes the instance so a user can play multiple games
        public static void DeleteInstance()
        {
            _instance = null;
        }

        // Constructor to initialize board dimensions and player.
        private Board()
        {
            boardWidth = 10; // Set initial width.
            boardHeight = 10; // Set initial height.
            board = new int[boardHeight, boardWidth]; // Initialize the board.
            player = new Player(); // Create a player instance.
        }

        // Executes a list of commands on the player. And returns endstate
        public string PlayBoard(List<ICommand> commands)
        {
            DeleteInstance();
            GetInstance();
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
    }
}

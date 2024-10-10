using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MSO2
{
    public class Board
    {
        private int[,] board { get; set; }
        public static int boardHeight { get; private set; }
        public static int boardWidth { get; private set; }
        private Player player;
        private static Board _instance;

        public static Board GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }
            return _instance;
        }

        private Board()
        {
            board = new int[boardHeight, boardWidth];
            boardWidth = 100;
            boardHeight = 100;
            player = new Player();
        }

        internal void PlayBoard(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(player);
            }

            player.PrintEndState();
        }

        public static (int, int) BoardBounds((int, int) position)
        {
            (int, int) upperBounds = (Math.Min(position.Item1, boardWidth), Math.Min(position.Item2, boardHeight));
            (int, int) lowerBounds = (Math.Max(upperBounds.Item1, 0), Math.Max(upperBounds.Item2, 0));
            return lowerBounds;
        }
    }
}

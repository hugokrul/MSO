using MSO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal class Player
    {
        private (int, int) position;
        public enum facing { North, East, South, West };
        private facing currentFacing { get; set; }
        private List<(int, int)> visitedPositions;
        private List<string> log { get; set; }

        public Player()
        {
            position = (0, 0);
            currentFacing = facing.South;
            log = new List<string>();
            visitedPositions = new List<(int, int)> { (0, 0) };
        }

        public void Turn(string direction)
        {
            switch (direction)
            {
                case "left":
                    currentFacing = (facing)(((int)currentFacing + 3) % 4);
                    log.Add("Turn left");
                    break;
                case "right":
                    currentFacing = (facing)(((int)currentFacing + 1) % 4);
                    log.Add("Turn Right");
                    break;
            }
        }

        public void Move(int amountOfSteps)
        {
            switch (currentFacing)
            {
                case facing.North:
                    position = Board.BoardBounds((position.Item1, position.Item2 - amountOfSteps));
                    break;
                case facing.South:
                    position = Board.BoardBounds((position.Item1, position.Item2 + amountOfSteps));
                    break;
                case facing.East:
                    position = Board.BoardBounds((position.Item1 + amountOfSteps, position.Item2));
                    break;
                case facing.West:
                    position = Board.BoardBounds((position.Item1 - amountOfSteps, position.Item2));
                    break;
            }
            visitedPositions.Add(position);
            log.Add($"Move {amountOfSteps}");
        }

        public void PrintEndState()
        {
            Console.WriteLine($"[{string.Join("], [", log)}] \nEnd state {position} facing {currentFacing}");
        }
    }
}

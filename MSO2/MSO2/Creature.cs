using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal abstract class Creature
    {
        protected (int, int) position;
        public enum facing { North, East, South, West };
        protected facing currentFacing { get; set; }

        protected List<(int, int)> visitedPositions;
        protected List<string> log { get; set; }


        public virtual void Turn(string direction)
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

        public virtual void Move(int amountOfSteps)
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
    }
}

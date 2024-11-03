using System;
using System.Collections.Generic;

namespace MSO2
{
    public abstract class Creature
    {
        public (int, int) Position { get; set; }  // Current position

        public enum Facing { North, East, South, West };
        public Facing CurrentFacing { get; protected set; }

        public List<(int, int)> VisitedPositions { get; protected set; } = []; // Tracks all visited positions
        protected List<string> Log { get; set; } = [];  // Logs actions

        /// <summary>
        /// Turns the creature left or right and logs the action.
        /// </summary>
        public virtual void Turn(string direction)
        {
            switch (direction)
            {
                case "left":
                    // Iterates through the facing enum backwards
                    CurrentFacing = (Facing)(((int)CurrentFacing + 3) % 4);
                    Log.Add("Turn left");
                    break;
                case "right":
                    // Iterates throught the facing enum forwards
                    CurrentFacing = (Facing)(((int)CurrentFacing + 1) % 4);
                    Log.Add("Turn right");
                    break;
            }
        }

        /// <summary>
        /// Moves the creature and logs the movement.
        /// </summary>
        public virtual void Move(int amountOfSteps)
        {
            for (int i = 0; i < amountOfSteps; i++)
            {
                switch (CurrentFacing)
                {
                    case Facing.North:
                        Position = Board.BoardBounds((Position.Item1, Position.Item2 - 1));
                        break;
                    case Facing.South:
                        Position = Board.BoardBounds((Position.Item1, Position.Item2 + 1));
                        break;
                    case Facing.East:
                        Position = Board.BoardBounds((Position.Item1 + 1, Position.Item2));
                        break;
                    case Facing.West:
                        Position = Board.BoardBounds((Position.Item1 - 1, Position.Item2));
                        break;
                }
                VisitedPositions.Add(Position);
            }
            Log.Add($"Move {amountOfSteps}");
        }
    }
}

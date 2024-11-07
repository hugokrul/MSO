using System;
using System.Collections.Generic;

namespace MSO2
{
    public abstract class Creature
    {
        public Position Position { get; set; }  // Current position

        public enum Facing { North, East, South, West };
        public Facing CurrentFacing { get; protected set; }

        public List<Position> VisitedPositions { get; protected set; } = []; // Tracks all visited positions
        protected List<string> Log { get; set; } = [];  // Logs actions

        public bool RanInWall { get; protected set; } = false;

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
                Position nextPosition = Position.GetNextPosition(CurrentFacing);
                Position newPosition = Board.BoardBounds(nextPosition);
                if (newPosition.Equals(Position) || Position.InWall(Board.BoardArray, nextPosition)) RanInWall = true;
                Position = newPosition;
                VisitedPositions.Add(Position);
            }
            Log.Add($"Move {amountOfSteps}");
        }
    }
}

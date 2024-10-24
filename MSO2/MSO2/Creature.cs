﻿using System;
using System.Collections.Generic;

namespace MSO2
{
    public abstract class Creature
    {
        public (int, int) position { get; protected set; }  // Current position

        public enum facing { North, East, South, West };
        public facing currentFacing { get; protected set; }

        public List<(int, int)> visitedPositions { get; protected set; }  // Tracks all visited positions
        protected List<string> log { get; set; }  // Logs actions

        /// <summary>
        /// Turns the creature left or right and logs the action.
        /// </summary>
        public virtual void Turn(string direction)
        {
            switch (direction)
            {
                case "left":
                    // Iterates through the facing enum backwards
                    currentFacing = (facing)(((int)currentFacing + 3) % 4);
                    log.Add("Turn left");
                    break;
                case "right":
                    // Iterates throught the facing enum forwards
                    currentFacing = (facing)(((int)currentFacing + 1) % 4);
                    log.Add("Turn right");
                    break;
            }
        }

        /// <summary>
        /// Moves the creature and logs the movement.
        /// </summary>
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

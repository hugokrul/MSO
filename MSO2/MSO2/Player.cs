using MSO2;
using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Player : Creature
    {
        // Constructor initializes starting position, direction, log, and visited positions.
        public Player((int, int) pos)
        {
            Position = pos;
            CurrentFacing = Facing.South;
            Log = [];
            VisitedPositions = [pos];
        }

        // Prints the player's log and final state (position and direction).
        public string PrintEndState()
        {
            return $"[{string.Join("], [", Log)}] \nEnd state {Position} facing {CurrentFacing}";
        }
    }
}

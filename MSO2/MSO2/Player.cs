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
            position = pos;
            currentFacing = facing.South;
            log = new List<string>();
            visitedPositions = new List<(int, int)> { pos };
        }

        // Prints the player's log and final state (position and direction).
        public string PrintEndState()
        {
            return $"[{string.Join("], [", log)}] \nEnd state {position} facing {currentFacing}";
        }
    }
}

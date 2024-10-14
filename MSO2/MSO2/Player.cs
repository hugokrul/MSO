using MSO2;
using System;
using System.Collections.Generic;

namespace MSO2
{
    internal class Player : Creature
    {
        // Constructor initializes starting position, direction, log, and visited positions.
        public Player()
        {
            position = (0, 0);
            currentFacing = facing.East;
            log = new List<string>();
            visitedPositions = new List<(int, int)> { (0, 0) };
        }

        // Prints the player's log and final state (position and direction).
        public void PrintEndState()
        {
            Console.WriteLine($"[{string.Join("], [", log)}] \nEnd state {position} facing {currentFacing}");
        }
    }
}

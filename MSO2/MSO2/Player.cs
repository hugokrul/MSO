using MSO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    internal class Player : Creature
    {

        public Player()
        {
            position = (0, 0);
            currentFacing = facing.South;
            log = new List<string>();
            visitedPositions = new List<(int, int)> { (0, 0) };
        }

        

        public void PrintEndState()
        {
            Console.WriteLine($"[{string.Join("], [", log)}] \nEnd state {position} facing {currentFacing}");
        }
    }
}

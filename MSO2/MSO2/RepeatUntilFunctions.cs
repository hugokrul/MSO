using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    public static class RepeatUntilFunctions
    {
        public static bool WallAhead(Creature creature)
        {
            return true;
        }

        public static bool GridEdge(Creature creature)
        {
            int playerX = creature.Position.Item1;
            int playerY = creature.Position.Item2;
            int maxX = Board.BoardWidth - 1;
            int maxY = Board.BoardHeight - 1;

            switch (creature.CurrentFacing)
            {
                case Creature.Facing.North:
                    return playerY == 0;
                case Creature.Facing.South:
                    Console.WriteLine(playerY == maxY);
                    return playerY == maxY;
                case Creature.Facing.West:
                    return playerX == 0;
                case Creature.Facing.East:
                    return playerX == maxX;
                default:
                    return false;
            }
        }
    }
}

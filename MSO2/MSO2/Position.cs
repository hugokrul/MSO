using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    public class Position
    {
        public int X {  get; set; }
        public int Y {  get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Position GetNextPosition(Creature.Facing facing)
        {
            return facing switch
            {
                Creature.Facing.North => new Position(X, Y-1),
                Creature.Facing.South => new Position(X, Y+1),
                Creature.Facing.East => new Position(X+1, Y),
                Creature.Facing.West => new Position(X-1, Y),
                _ => this
            };
        }

        public override string ToString()
        {
            return (X, Y).ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Position other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            // Combine X and Y into a unique hash code
            return HashCode.Combine(X, Y);
        }
    }
}

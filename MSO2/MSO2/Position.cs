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
        public static Position FindStartPosition(string[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == "s")
                    {
                        return new Position(j, i); // Return the position as a tuple
                    }
                }
            }
            // return the most top left position
            return FindTopLeftPosition(b);
        }

        public static Position FindTopLeftPosition(string[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == "o")
                    {
                        return new Position(j, i);
                    }
                }
            }
            return new Position(-1, -1);
        }

        public static bool InWall(string[,] b, Position position)
        {
            List<Position> wallPositions = new List<Position>();

            for (int i = 0; i < b.GetLength(0); ++i)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == "+")
                    {
                        wallPositions.Add(new Position(j, i));
                    }
                }
            }

            return wallPositions.Contains(position);
        }

        public static Position FindEndPosition(string[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == "x")
                    {
                        return new Position(j, i);
                    }
                }
            }
            return new Position(-1, -1);
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

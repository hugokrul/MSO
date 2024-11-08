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

        // Returns the next position of a creature dependend on its facing
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

        // Returns the startposition of a board array
        // if there is no startposition found, it returns the most top left open posiiton.
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

        // finds the most top left position of a boardarray
        // if there is none found, the posision is set to (-1, -1)
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

        // Calculates if a player has hit the wall.
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

        // finds the endposition of a board array,
        // if none is found it returns (-1, -1)
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

        // overrides so it is possible to compare this datatype
        public override bool Equals(object obj)
        {
            if (obj is Position other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        // for the function which compares the two hashsets of positions
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            // Combine X and Y into a unique hash code
            return HashCode.Combine(X, Y);
        }
    }
}

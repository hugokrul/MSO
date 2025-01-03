﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO2
{
    public static class RepeatUntilFunctions
    {
        // this function gives back if a creature is eather facing a wall or the edge
        public static bool WallAhead(Creature creature)
        {
            HashSet<Position>? wallPositions = GetWallPositions();
            Position nextPosition = creature.Position.GetNextPosition(creature.CurrentFacing);
            return wallPositions.Contains(nextPosition) || GridEdge(creature);
        }

        // returns alls the wallpositions of a boardarray
        private static HashSet<Position>? GetWallPositions()
        {
            HashSet<Position> wallPositions = [];
            if (Board.BoardArray == null) return null;
            for (int i = 0; i < Board.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < Board.BoardArray.GetLength(1); j++)
                {
                    if (Board.BoardArray[j, i] == "+") 
                    {
                        wallPositions.Add(new Position(i, j));
                    }
                }
            }

            return wallPositions;
        }


        // returns if the player is facing the edge
        public static bool GridEdge(Creature creature)
        {
            int playerX = creature.Position.X;
            int playerY = creature.Position.Y;
            int maxX = Board.BoardWidth - 1;
            int maxY = Board.BoardHeight - 1;

            switch (creature.CurrentFacing)
            {
                case Creature.Facing.North:
                    return playerY == 0;
                case Creature.Facing.South:
                    return playerY == maxY;
                case Creature.Facing.West:
                    return playerX == 0;
                case Creature.Facing.East:
                    return playerX == maxX;
                default:
                    return false;
            }
        }

        public static Func<Creature, bool>? WhatPredicate(string? input)
        {
            return (input?.Trim()) switch
            {
                "wallahead" => WallAhead,
                "gridedge" =>  GridEdge,
                _ => null,
            };
        }
    }
}

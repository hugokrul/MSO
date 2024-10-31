using MSO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO3
{
    internal class Drawer
    {
        public static void drawBoard(Panel panel, Graphics g, Pen p)
        {
            int boardHeight = Board.boardHeight;
            int boardWidth = Board.boardWidth;

            int gridWidth = panel.Width / boardWidth;
            int gridHeight = panel.Height / boardHeight;

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    g.DrawRectangle(p, i * gridWidth, j * gridHeight, gridWidth - 1, gridHeight - 1);
                }
            }

            drawPlayer(g, gridWidth, gridHeight);
            drawLocations(g, gridWidth, gridHeight);
        }

        public static void drawLocations(Graphics g, int width, int height)
        {
            List<(int, int)> visitedPositions = Board.player.visitedPositions;

            for (int i = 0; i < visitedPositions.Count - 1; i++)
            {
                (int, int) oldPosition = visitedPositions[i];
                int oldX = (oldPosition.Item1 * width) + (width / 2);
                int oldY = (oldPosition.Item2 * height) + (height / 2);

                (int, int) currentPosition = visitedPositions[i + 1];
                int currentX = (currentPosition.Item1 * width) + (width / 2);
                int currentY = (currentPosition.Item2 * height) + (height / 2);

                g.DrawLine(new Pen(Color.Blue, 5), new Point(oldX, oldY), new Point(currentX, currentY));
            }
        }

        public static void drawPlayer(Graphics g, int width, int height)
        {
            (int, int) playerPosition = Board.player.position;

            int Posx = playerPosition.Item1 * width;
            int Posy = playerPosition.Item2 * height;
            float angle = 0;

            switch (Board.player.currentFacing)
            {
                case Creature.facing.North:
                    angle = 180;
                    break;
                case Creature.facing.South:
                    angle = 0;
                    break;
                case Creature.facing.West:
                    angle = 270;
                    break;
                case Creature.facing.East:
                    angle = 90;
                    break;
            }

            DrawImageWithRotation(g, Home.playerImage, angle, Posx, Posy, width, height);
        }

        public static void DrawImageWithRotation(Graphics g, Image image, float angle, int PosX, int Posy, int cellWidth, int CellHeight)
        {
            var originalTransform = g.Transform; //Save current graphics transform

            g.TranslateTransform(PosX + cellWidth / 2, Posy + CellHeight / 2); //Get middle of originall image
            g.RotateTransform(angle); //Rotate graphics with an angle
            g.DrawImage(image, -cellWidth / 2, -CellHeight / 2, cellWidth, CellHeight); //Draw the image
            g.Transform = originalTransform; //Reset the original rotation
        }
    }
}

using MSO2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    internal static class Drawer
    {
        public static void DrawBoard(Panel panel, Graphics g, Pen p, Board board, bool characterVisible = true)
        {
            int boardHeight = Board.BoardHeight;
            int boardWidth = Board.BoardWidth;

            int gridWidth = panel.Width / boardWidth;
            int gridHeight = panel.Height / boardHeight;

            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    g.DrawRectangle(p, i * gridWidth, j * gridHeight, gridWidth - 1, gridHeight - 1);
                    if (board != null && Board.BoardArray[j, i] == "+") g.FillRectangle(new SolidBrush(Color.Orange), i * gridWidth, j * gridHeight, gridWidth - 1, gridHeight - 1);
                }
            }

            DrawLocations(g, gridWidth, gridHeight, board);
            if (characterVisible) DrawPlayer(g, gridWidth, gridHeight, board);
        }

        public static void DrawLocations(Graphics g, int width, int height, Board board)
        {
            List<(int, int)> visitedPositions = board.Player.VisitedPositions.ConvertAll(c => (c.X, c.Y));

            for (int i = 0; i < visitedPositions.Count - 1; i++)
            {
                (int, int) oldPosition = visitedPositions[i];
                int oldX = (oldPosition.Item1 * width) + (width / 2);
                int oldY = (oldPosition.Item2 * height) + (height / 2);

                (int, int) currentPosition = visitedPositions[i + 1];
                int currentX = (currentPosition.Item1 * width) + (width / 2);
                int currentY = (currentPosition.Item2 * height) + (height / 2);

                g.DrawLine(new Pen(Color.FromArgb(253, 203, 110), 5), new Point(oldX, oldY), new Point(currentX, currentY));
            }
        }

        public static void DrawPlayer(Graphics g, int width, int height, Board board)
        {
            int Posx = board.Player.Position.X * width;
            int Posy = board.Player.Position.Y * height;
            float angle = 0;

            switch (board.Player.CurrentFacing)
            {
                case Creature.Facing.North:
                    angle = 180;
                    break;
                case Creature.Facing.South:
                    angle = 0;
                    break;
                case Creature.Facing.West:
                    angle = 270;
                    break;
                case Creature.Facing.East:
                    angle = 90;
                    break;
            }

            DrawImageWithRotation(g, Home.GetPlayerImage(), angle, Posx, Posy, width, height);
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

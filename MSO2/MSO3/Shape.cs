using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MSO2;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    public partial class Shape : BaseForm
    {
        private Board? board;
        private string[,] tempBoard;
        private static Shape? instance;

        private Shape() : base()
        {
            InitializeComponent();
        }

        public static Shape GetInstance()
        {
            if (instance == null)
            {
                instance = new Shape();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (board != null)
            {
                Graphics? g = e.Graphics;
                Pen? whitepen = new(Color.White, 1);

                Drawer.DrawBoard((Panel)sender, g, whitepen, board, false);
            }
        }

        public static bool SameShapes(List<(int, int)> list1, List<(int, int)> list2)
        {
            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home home = Home.GetInstance();
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Hide();
        }

        private void importBoard_Click_1(object sender, EventArgs e)
        {
            string[]? boardArrayStrings = ImportFile.ImportBoardArrayByPath();
            if (boardArrayStrings != null)
            {
                tempBoard = Board.MakeBoardArray(boardArrayStrings);
                Position playerPosition = Position.FindStartPosition(tempBoard);
                board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.X, playerPosition.Y);
                Board.BoardArray = tempBoard;

                boardPanel.Invalidate();
            }
        }

        private void checkBoard_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                List<(int, int)>? correctVisitedPlaces = new List<(int, int)>();
                (int, int) startPosition = (0, 0);
                for (int i = 0; i < tempBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < tempBoard.GetLength(1); j++)
                    {
                        if (tempBoard[i, j] == "s" || tempBoard[i, j] == "o")
                        {
                            correctVisitedPlaces.Add((j, i));
                        }
                        if (tempBoard[i, j] == "s") startPosition = (j, i);
                    }
                }

                correctVisitedPlaces.Add(startPosition);

                if (SameShapes(board.Player.VisitedPositions.ConvertAll(c => (c.X, c.Y)), correctVisitedPlaces))
                {
                    MessageBox.Show("Shape is correct!");
                }
                else
                {
                    MessageBox.Show("Shape is incorrect!");
                }
            }
        }

        private void RunBoard(bool showMetrics = false)
        {
            if (board != null)
            {
                Position playerPosition = Position.FindStartPosition(tempBoard);
                board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.X, playerPosition.Y);
                Board.BoardArray = tempBoard;
                string[] commandArray = [.. ownProgram.Text.Split('\n')];

                List<ICommand>? commands = CommandParser.Parse(commandArray);
                board.PlayBoard(commands);

                if (board.Player.RanInWall)
                {
                    MessageBox.Show("You ran into a wall! be more carefull next time");
                    return;
                }

                boardPanel.Invalidate();
                if (showMetrics) Sandbox.ShowMetrics(commandArray);
            }
            else
            {
                MessageBox.Show("Import a board first.");
            }
        }

        private void ExecuteBoard_Click_1(object sender, EventArgs e)
        {
            RunBoard();
        }

        private void CalculateMetricsButton_Click(object sender, EventArgs e)
        {
            RunBoard(true);
        }
    }
}

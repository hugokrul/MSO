using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MSO2;

namespace MSO3
{
    public partial class Shape : BaseForm
    {
        private Board? board;
        string[,] tempBoard = { { } };

        public Shape() : base()
        {
            InitializeComponent();
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            Home.instance.StartPosition = FormStartPosition.CenterScreen;
            Home.instance.Show();
            this.Hide();
        }



        private void ImportBoard_Click(object sender, EventArgs e)
        {

            string? boardFile = Interaction.InputBox("Give the full path of the file where the board is stored", "Board file");
            string[] boardArray = File.ReadAllLines(boardFile);


            int rows = boardArray.Length;
            int cols = boardArray[0].Length;
            tempBoard = new string[rows, cols];



            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempBoard[i, j] = boardArray[i][j].ToString();
                }
            }

            (int, int) playerPosition = FindStartPosition(tempBoard);
            board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1);
            board.BoardArray = tempBoard;

            boardPanel.Invalidate();
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (board != null)
            {
                Graphics? g = e.Graphics;
                Pen? blackPen = new Pen(Color.Black, 1);

                Drawer.DrawBoard((Panel)sender, g, blackPen, board, false);
            }
        }

        private void ExecuteBoard_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                (int, int) playerPosition = FindStartPosition(tempBoard);
                board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1);
                board.BoardArray = tempBoard;

                string[] commandArray = ownProgram.Text.Split('\n');
                List<ICommand>? commands = CommandParser.Parse(commandArray);
                board.PlayBoard(commands);

                boardPanel.Invalidate();

                Sandbox.ShowMetrics(commandArray);
            }
            else
            {
                MessageBox.Show("Import a board first.");
            }
        }

        private static (int, int) FindStartPosition(string[,] b)
        {
            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    if (b[i, j] == "s")
                    {
                        return (i, j); // Return the position as a tuple
                    }
                }
            }
            return (-1, -1);
        }

        private void CheckShape_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                List<(int, int)>? correctVisitedPlaces = new List<(int,int)>();
                (int, int) startPosition = (0, 0);
                for (int i = 0; i < board.BoardArray.GetLength(0); i++)
                {
                    for (int j = 0; j < board.BoardArray.GetLength(1); j++)
                    {
                        if (board.BoardArray[i, j] == "s" || board.BoardArray[i, j] == "o")
                        {
                            correctVisitedPlaces.Add((j, i));
                        }
                        if (board.BoardArray[i, j] == "s") startPosition = (j, i);
                    }
                }

                correctVisitedPlaces.Add(startPosition);

                if (SameShapes(board.Player.VisitedPositions, correctVisitedPlaces))
                {
                    MessageBox.Show("Shape is correct!");
                }
                else
                {
                    MessageBox.Show("Shape is incorrect!");
                }
            }
        }

        private static bool SameShapes(List<(int, int)> list1,  List<(int, int)> list2)
        {
            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }
    }
}

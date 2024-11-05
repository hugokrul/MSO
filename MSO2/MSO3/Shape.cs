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
        string[,] tempBoard = { { } };
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

        public static (int, int) FindStartPosition(string[,] b)
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
            string? boardFile = Interaction.InputBox("Give the full path of the file where the board is stored", "Board file");
            if (boardFile == "") return;
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
            board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1)
            {
                BoardArray = tempBoard
            };

            boardPanel.Invalidate();
        }

        private void checkBoard_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                List<(int, int)>? correctVisitedPlaces = new List<(int, int)>();
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

        private void ExecuteBoard_Click_1(object sender, EventArgs e)
        {
            if (board != null)
            {
                (int, int) playerPosition = FindStartPosition(tempBoard);
                board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1)
                {
                    BoardArray = tempBoard
                };

                string[] commandArray = ownProgram.Text.Split('\n').ToArray();
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
    }
}

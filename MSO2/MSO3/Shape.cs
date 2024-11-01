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
        private Board board;
        string[,] tempBoard;

        public Shape() : base()
        {
            InitializeComponent();
        }

        private void homePage_Click(object sender, EventArgs e)
        {
            Home homePage = Home.instance;
            homePage.StartPosition = FormStartPosition.CenterScreen;
            homePage.Show();
            this.Hide();
        }



        private void importBoard_Click(object sender, EventArgs e)
        {

            string boardFile = Interaction.InputBox("Give the full path of the file where the board is stored", "Board file");
            //string boardFile = @"C:\Users\hugok\Documents\code\MSO\MSO2\MSO2\MSO3\board.txt";
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

            (int, int) playerPosition = findStartPosition(tempBoard);
            board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1);
            board.boardArray = tempBoard;

            boardPanel.Invalidate();
        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (board != null)
            {
                Graphics g = e.Graphics;
                Pen blackPen = new Pen(Color.Black, 1);

                Drawer.drawBoard((Panel)sender, g, blackPen, board, false);
            }
        }

        private void ExecuteBoard_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                (int, int) playerPosition = findStartPosition(tempBoard);
                board = new Board(tempBoard.GetLength(0), tempBoard.GetLength(1), playerPosition.Item2, playerPosition.Item1);
                board.boardArray = tempBoard;


                List<ICommand> commands = CommandParser.Parse(ownProgram.Text.Split('\n'));
                board.PlayBoard(commands);
                boardPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Import a board first.");
            }
        }

        private (int, int) findStartPosition(string[,] b)
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

        private void checkShape_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                List<(int,int)> correctVisitedPlaces = new List<(int,int)>();
                (int, int) startPosition = (0, 0);
                for (int i = 0; i < board.boardArray.GetLength(0); i++)
                {
                    for (int j = 0; j < board.boardArray.GetLength(1); j++)
                    {
                        if (board.boardArray[i, j] == "s" || board.boardArray[i, j] == "o")
                        {
                            correctVisitedPlaces.Add((j, i));
                        }
                        if (board.boardArray[i, j] == "s") startPosition = (j, i);
                    }
                }

                correctVisitedPlaces.Add(startPosition);

                if (sameShapes(board.player.visitedPositions, correctVisitedPlaces))
                {
                    MessageBox.Show("Shape is correct!");
                }
                else
                {
                    MessageBox.Show("Shape is incorrect!");
                }
            }
        }

        private bool sameShapes(List<(int, int)> list1,  List<(int, int)> list2)
        {
            list1.Sort();
            list2.Sort();

            return list1.SequenceEqual(list2);
        }
    }
}

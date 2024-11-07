using MSO2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSO3
{
    public partial class Pathfinding : BaseForm
    {
        private Board? board;
        string[,] tempBoard = { { } };
        private static Pathfinding? instance;

        private Pathfinding()
        {
            InitializeComponent();
        }

        public static Pathfinding GetInstance()
        {
            if (instance == null)
            {
                instance = new Pathfinding();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Home home = Home.GetInstance();
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Hide();
        }

        private void importBoard_Click(object sender, EventArgs e)
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

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            if (board != null)
            {
                Graphics? g = e.Graphics;
                Pen? whitepen = new(Color.White, 1);

                Drawer.DrawBoard((Panel)sender, g, whitepen, board, false);
            }
        }

        private void ExecuteBoard_Click(object sender, EventArgs e)
        {
            RunBoard();
        }

        private void CalculateMetricsButton_Click(object sender, EventArgs e)
        {
            RunBoard(true);
        }

        private void checkBoard_Click(object sender, EventArgs e)
        {
            if (board != null)
            {
                Position playerPosition = board.Player.Position;
                Position endPosition = Position.FindEndPosition(tempBoard);

                if (playerPosition.Equals(endPosition))
                {
                    MessageBox.Show("Shape is correct!");
                }
                else if (endPosition.Equals(new Position(-1, -1)))
                {
                    MessageBox.Show("There is no end position found, insert a different board");
                }
                else
                {
                    MessageBox.Show("Shape is incorrect!");
                }
            }
        }
    }
}

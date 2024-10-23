using MSO2;

namespace MSO3
{
    public partial class Home : Form
    {
        public static Home instance;
        public static Board board;

        public Home(Board b)
        {
            InitializeComponent();
            board = b;
            instance = this;
        }

        private void sandboxNav_Click(object sender, EventArgs e)
        {
            Sandbox sandboxPage = new Sandbox();
            sandboxPage.StartPosition = FormStartPosition.CenterScreen;
            sandboxPage.Show();
            this.Hide();
        }

        private void shapePage_Click(object sender, EventArgs e)
        {
            Shape shapePage = new Shape();
            shapePage.StartPosition = FormStartPosition.CenterScreen;
            shapePage.Show();
            this.Hide();
        }

        private void pathfindingPage_Click(object sender, EventArgs e)
        {
            Pathfinding pathfindingPage = new Pathfinding();
            pathfindingPage.StartPosition = FormStartPosition.CenterScreen;
            pathfindingPage.Show();
            this.Hide();
        }

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
                int oldX = (oldPosition.Item1* width) + (width / 2);
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

            g.FillEllipse(new SolidBrush(Color.Red), playerPosition.Item1*width, playerPosition.Item2*height, width - 1, height - 1);
        }
    }
}

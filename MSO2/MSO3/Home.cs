using System.Diagnostics.CodeAnalysis;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    public partial class Home : BaseForm
    {
        private static Home? instance;

        private static Image? playerImage, backgroundButtonImage;

        private ContextMenuStrip? menuStrip;

        private Home() : base()
        {
            InitializeComponent();

            GetPlayerImage();
            GetBackgroundButtonImage();

            AddPlayMenuStrip();
        }

        // retrieves the playerImage
        public static Image GetPlayerImage()
        {
            if (playerImage == null)
            {
                byte[] imageData = Properties.Resources._whiteRobot;
                using MemoryStream ms = new(imageData);
                playerImage = Image.FromStream(ms);
            }
            return playerImage;
        }

        // retrieves the backgroundImage
        private static Image GetBackgroundButtonImage()
        {
            if (backgroundButtonImage == null)
            {
                byte[] imageData1 = Properties.Resources.gradient;
                using MemoryStream ms = new(imageData1);
                backgroundButtonImage = Image.FromStream(ms);
            }
            return backgroundButtonImage;
        }

        // used for the singleton pattern
        public static Home GetInstance()
        {
            if (instance == null)
            {
                instance = new Home();
            }
            return instance;
        }

        // adds a menustrip with the choices of programs.
        private void AddPlayMenuStrip()
        {
            menuStrip = new ContextMenuStrip
            {
                BackgroundImage = GetBackgroundButtonImage(),
                BackgroundImageLayout = ImageLayout.Stretch
            };

            //Add item 1
            ToolStripMenuItem item1 = new("Sandbox")
            {
                Font = new Font("Snap ITC", 9, FontStyle.Regular),
                ForeColor = Color.White,
                Image = playerImage,
                BackColor = Color.FromArgb(9, 132, 227)
            };
            item1.Click += SandBoxPage_Click;

            //Add item 2
            ToolStripMenuItem item2 = new("Shape")
            {
                Font = new Font("Snap ITC", 9, FontStyle.Regular),
                ForeColor = Color.White,
                Image = playerImage,
                BackColor = Color.FromArgb(9, 132, 227)
            };
            item2.Click += ShapePage_Click;

            ToolStripMenuItem item3 = new("Pathfinding")
            {
                Font = new Font("Snap ITC", 9, FontStyle.Regular),
                ForeColor = Color.White,
                Image = playerImage,
                BackColor = Color.FromArgb(9, 132, 227)
            };
            item3.Click += PathfindingPage_Click;

            //Add both items
            menuStrip.Items.Add(item1);
            menuStrip.Items.Add(item2);
            menuStrip.Items.Add(item3);
        }

        // retrieves the instance of the sandbox page, opens it and closes the home page
        private void SandBoxPage_Click(object? sender, EventArgs e)
        {
            Sandbox sandboxPage = Sandbox.GetInstance();
            sandboxPage.StartPosition = FormStartPosition.CenterScreen;
            sandboxPage.Show();
            this.Hide();
        }

        // retrieves the instance of the shape page, opens it and closes the home page

        private void ShapePage_Click(object? sender, EventArgs e)
        {
            Shape shapePage = Shape.GetInstance();
            shapePage.StartPosition = FormStartPosition.CenterScreen;
            shapePage.Show();
            this.Hide();
        }

        // retrieves the instance of the pathfinding page, opens it and closes the home page
        private void PathfindingPage_Click(object? sender, EventArgs e)
        {
            Pathfinding pathfindingPage = Pathfinding.GetInstance();
            pathfindingPage.StartPosition = FormStartPosition.CenterScreen;
            pathfindingPage.Show();
            this.Hide();
        }

        // exits the program
        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // opens the playMenu
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (menuStrip == null)
            {
                AddPlayMenuStrip();
            }
            else
            {
                menuStrip.Show(PlayButton, PlayButton.Width, 0);
            }
            
        }
    }
}
namespace MSO3
{
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

        public static Image GetPlayerImage()
        {
            if (playerImage == null)
            {
                byte[] imageData = Properties.Resources._whiteRobot;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    playerImage = Image.FromStream(ms);
                }
            }
            return playerImage;
        }

        private static Image GetBackgroundButtonImage()
        {
            if (backgroundButtonImage == null)
            {
                byte[] imageData1 = Properties.Resources.gradient;
                using (MemoryStream ms = new MemoryStream(imageData1))
                {
                    backgroundButtonImage = Image.FromStream(ms);
                }
            }
            return backgroundButtonImage;
        }

        public static Home GetInstance()
        {
            if (instance == null)
            {
                instance = new Home();
            }
            return instance;
        }

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
            item1.Click += SandboxNav_Click;

            //Add item 2
            ToolStripMenuItem item2 = new("Shape")
            {
                Font = new Font("Snap ITC", 9, FontStyle.Regular),
                ForeColor = Color.White,
                Image = playerImage,
                BackColor = Color.FromArgb(9, 132, 227)
            };
            item2.Click += ShapePage_Click;

            //Add both items
            menuStrip.Items.Add(item1);
            menuStrip.Items.Add(item2);
        }

        private void SandboxNav_Click(object sender, EventArgs e)
        {
            Sandbox sandboxPage = new()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            sandboxPage.Show();
            this.Hide();
        }

        private void ShapePage_Click(object sender, EventArgs e)
        {
            Shape shapePage = new()
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            shapePage.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            menuStrip.Show(PlayButton, PlayButton.Width, 0);
            
        }
    }
}
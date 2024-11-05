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
            menuStrip = new ContextMenuStrip();
            menuStrip.BackgroundImage = GetBackgroundButtonImage();
            menuStrip.BackgroundImageLayout = ImageLayout.Stretch;

            //Add item 1
            ToolStripMenuItem item1 = new ToolStripMenuItem("Sandbox");
            item1.Font = new Font("Snap ITC", 9, FontStyle.Regular);
            item1.ForeColor = Color.White;
            item1.Image = playerImage;
            item1.BackColor = Color.FromArgb(9, 132, 227);
            item1.Click += sandboxNav_Click;

            //Add item 2
            ToolStripMenuItem item2 = new ToolStripMenuItem("Shape");
            item2.Font = new Font("Snap ITC", 9, FontStyle.Regular);
            item2.ForeColor = Color.White;
            item2.Image = playerImage;
            item2.BackColor = Color.FromArgb(9, 132, 227);
            item2.Click += shapePage_Click;

            //Add both items
            menuStrip.Items.Add(item1);
            menuStrip.Items.Add(item2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            menuStrip.Show(PlayButton, PlayButton.Width, 0);
            
        }
    }
}
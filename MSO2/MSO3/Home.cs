using MSO2;
using System.Drawing.Drawing2D;

namespace MSO3
{
    public partial class Home : BaseForm
    {
        public static Home instance;
        public static Board board;

        public static Image playerImage;

        public Home(Board b) : base()
        {
            InitializeComponent();
            board = b;
            instance = this;

            //Load image from resources folder
            byte[] imageData = Properties.Resources._whiteRobot;
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                playerImage = Image.FromStream(ms);
            }
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

        private void Home_Load(object sender, EventArgs e)
        {
            
        }
    }
}
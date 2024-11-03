using MSO2;
using System.Drawing.Drawing2D;

namespace MSO3
{
    public partial class Home : BaseForm
    {
        public static Home instance;

        public static Image playerImage;

        public Home() : base()
        {
            InitializeComponent();
            instance = this;

            //Load image from resources folder
            byte[] imageData = Properties.Resources._whiteRobot;
            using MemoryStream ms = new MemoryStream(imageData);
            playerImage = Image.FromStream(ms);
        }

        private void SandboxNav_Click(object sender, EventArgs e)
        {
            Sandbox sandboxPage = new Sandbox
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            sandboxPage.Show();
            this.Hide();
        }

        private void ShapePage_Click(object sender, EventArgs e)
        {
            Shape shapePageFromHome = new Shape
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            shapePageFromHome.Show();
            this.Hide();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSO2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MSO3
{
    public partial class Sandbox : Form
    {
        public Sandbox()
        {
            InitializeComponent();
        }

        private void homeNav_Click(object sender, EventArgs e)
        {
            Home homePage = Home.instance;
            homePage.StartPosition = FormStartPosition.CenterScreen;
            homePage.Show();
            this.Hide();
        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen blackPen = new Pen(Color.Black, 1);

            Home.drawBoard((Panel)sender, g, blackPen);
        }
    }
}

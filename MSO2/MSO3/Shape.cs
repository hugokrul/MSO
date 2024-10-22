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
    public partial class Shape : Form
    {
        public Shape()
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
    }
}

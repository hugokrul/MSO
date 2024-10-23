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

        private void executeBoard_Click(object sender, EventArgs e)
        {
            string? difficulty = executionWay.GetItemText(executionWay.SelectedItem);

            string[] programCommands = chosenProgram(difficulty);

            List<ICommand> commands = CommandParser.Parse(programCommands);

            Home.board.PlayBoard(commands);

            boardPanel.Invalidate();
        }

        private string[] chosenProgram(string? choice)
        {
            switch (choice)
            {
                case "Hard":
                    Console.WriteLine("hard in");
                    return MSO2.Program.availablePrograms[1];
                case "Advanced":
                    return MSO2.Program.availablePrograms[2];
                case "Import":
                    string path = filePathInput.Text;
                    return File.ReadAllLines(path);
                default:
                    return MSO2.Program.availablePrograms[0];
            }
        }

        private void executionWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

            string input = cb.GetItemText(cb.SelectedItem);

            if (input == "Import")
            {
                if (!File.Exists(filePathInput.Text)) executeBoard.Visible = false; 
                else executeBoard.Visible = true; 
                filePathInput.Visible = true;
            }
            else filePathInput.Visible = false;


        }

        private void filePathInput_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(filePathInput.Text)) executeBoard.Visible = false;
            else executeBoard.Visible = true;
        }
    }
}


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
using Microsoft.VisualBasic;

namespace MSO3
{
    public partial class Sandbox : BaseForm
    {
        private string file = null;
        private string[] originalCommands;

        public Sandbox() : base()
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
            Home.board = new Board();

            string? difficulty = executionWay.GetItemText(executionWay.SelectedItem);

            originalCommands = chosenProgram(difficulty);

            List<ICommand> commands = CommandParser.Parse(originalCommands);

            if (file != null) 
            {
                Home.board.name = Path.GetFileName(file);
            }
            else
            {
                Home.board.name = originalCommands[0].Split(' ')[0] != "Name:" ? null : originalCommands[0].Split(' ')[1];
            }

            Home.board.PlayBoard(commands);

            boardPanel.Invalidate();
            this.Text = $"Robologic {Home.board.name}";

            if (executionWay.Text != "Write your own") ownProgram.Text = string.Join(Environment.NewLine, originalCommands);
        }

        private string[] chosenProgram(string? choice)
        {
            switch (choice)
            {
                case "Hard":
                    return MSO2.Program.availablePrograms[1].Skip(1).ToArray();
                case "Advanced":
                    return MSO2.Program.availablePrograms[2].Skip(1).ToArray();
                case "Import":
                    if (file == null)
                    {
                        string path = filePathInput.Text;
                        file = path;
                        return File.ReadAllLines(path);
                    }
                    else
                    {
                        return ownProgram.Text.Split('\n');
                    }
                case "Write your own":
                    ownProgram.ReadOnly = false;
                    return ownProgram.Text.Split('\n');
                default:
                    return MSO2.Program.availablePrograms[0].Skip(1).ToArray();
            }
        }

        private void updateButtons(string input)
        {
            if (input == "Import")
            {
                if (!File.Exists(filePathInput.Text)) executeBoard.Visible = false;
                else executeBoard.Visible = true;
                filePathInput.Visible = true;

                saveProgram.Visible = true;
                ownProgram.ReadOnly = false;
            }
            else
            {
                saveProgram.Visible = false;
                filePathInput.Visible = false;
                executeBoard.Visible = true;
                ownProgram.ReadOnly = true;
            }

            if (input == "Write your own")
            {
                saveProgram.Visible = true;
                ownProgram.ReadOnly = false;
            }
        }

        private void executionWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!programChanged())
            {
                ownProgram.Text = "";
                System.Windows.Forms.ComboBox cb = (System.Windows.Forms.ComboBox)sender;

                string input = cb.GetItemText(cb.SelectedItem);
                updateButtons(input);
            }
            else
            {
                executionWay.SelectedIndexChanged -= new EventHandler(executionWay_SelectedIndexChanged);
                executionWay.Text = "Import";
                executionWay.SelectedIndexChanged += new EventHandler(executionWay_SelectedIndexChanged);
            }
        }

        private void filePathInput_TextChanged(object sender, EventArgs e)
        {

            if (!File.Exists(filePathInput.Text)) executeBoard.Visible = false;
            else executeBoard.Visible = true;
        }

        private void Sandbox_Load(object sender, EventArgs e)
        {
            file = null;
            this.Text = $"Robologic {Home.board.name}";
            switch (Home.board.name)
            {
                case "BasicProgram":
                    executionWay.Text = "Basic";
                    break;
                case "HardProgram":
                    executionWay.Text = "Hard";
                    break;
                case "AdvancedProgram":
                    executionWay.Text = "Advanced";
                    break;
                default:
                    executionWay.Text = "";
                    break;
            }
        }

        private void ownProgram_TextChanged(object sender, EventArgs e)
        {
        }

        private void saveProgram_Click(object sender, EventArgs e)
        {
            if (executionWay.Text == "Import")
            {
                File.WriteAllText(file, ownProgram.Text);
                string[] newCommands = File.ReadAllLines(file);
                originalCommands = newCommands;
                ownProgram.Text = string.Join(Environment.NewLine, newCommands);
            }
            else if (executionWay.Text == "Write your own")
            {
                string name = Interaction.InputBox("Title of the program", "Save", "Name...");
                if (name != "")
                {
                    File.Create(@"..\..\..\" + name + ".txt").Close();
                    file = Path.GetFullPath(@"..\..\..\" + name + ".txt");
                    File.WriteAllText(file, ownProgram.Text);
                    executionWay.Text = "Import";
                    ownProgram.Text = string.Join(Environment.NewLine, File.ReadAllText(file));
                    filePathInput.Text = file;
                }
                else
                {
                    MessageBox.Show("The file must have a name");
                }
            }
        }

        private bool programChanged()
        {
            if (ownProgram.Text == "") return false;
            if (ownProgram.ReadOnly) return false;
            //Console.WriteLine(!hardcodedPrograms.Contains(executionWay.Text));
            if (ownProgram.Text.Split('\n') != originalCommands);
            {
                DialogResult result = MessageBox.Show("Are you sure? there are unsaved changes", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;

        }
    }
}


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
using Microsoft.VisualBasic;

namespace MSO3
{
    public partial class Sandbox : BaseForm
    {
        private string file = null;
        private List<string> originalCommands = new List<string>();
        private string previousExecutionWay;

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

            Drawer.drawBoard((Panel)sender, g, blackPen);
        }

        private void executeBoard_Click(object sender, EventArgs e)
        {
            Home.board = new Board();
            string? difficulty = executionWay.GetItemText(executionWay.SelectedItem);
            originalCommands = chosenProgram(difficulty);
            List<ICommand> commands = CommandParser.Parse(originalCommands.ToArray());

            if (file != null) Home.board.name = Path.GetFileName(file);

            Home.board.PlayBoard(commands);

            boardPanel.Invalidate();
            this.Text = $"Robologic {Home.board.name}";

            if (executionWay.Text != "Write your own") ownProgram.Text = string.Join(Environment.NewLine, originalCommands);
        }

        private List<string> chosenProgram(string? choice)
        {
            switch (choice)
            {
                case "Basic":
                    return MSO2.Program.availablePrograms[0].Skip(1).ToList();
                case "Hard":
                    return MSO2.Program.availablePrograms[1].Skip(1).ToList();
                case "Advanced":
                    return MSO2.Program.availablePrograms[2].Skip(1).ToList();
                case "Import":
                    return runImportedProgram();
                case "Write your own":
                    ownProgram.ReadOnly = false;
                    return ownProgram.Text.Split('\n').ToList();
            }
            return new List<string>();
        }

        private List<string> runImportedProgram()
        {
            if (file != null && ownProgram.Text != "")
            {
                save();
            }
            string path = filePathInput.Text;
            file = path;
            return File.ReadAllLines(path).ToList();
        }

        private void updateButtons(string input)
        {
            if (input == "Import")
            {
                fileExistence();
                filePathInput.Visible = true;
                saveProgram.Visible = true;
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

                string input = executionWay.Text;
                previousExecutionWay = input;
                updateButtons(input);
            }
            else
            {
                executionWay.SelectedIndexChanged -= new EventHandler(executionWay_SelectedIndexChanged);
                executionWay.Text = previousExecutionWay;
                executionWay.SelectedIndexChanged += new EventHandler(executionWay_SelectedIndexChanged);
            }
        }

        private void filePathInput_TextChanged(object sender, EventArgs e)
        {
            fileExistence();
        }

        private void fileExistence()
        {
            string[] allowedFiles = { ".txt" };
            if (!File.Exists(filePathInput.Text) || !allowedFiles.Contains(Path.GetExtension(filePathInput.Text)))
            {
                saveProgram.Visible = false;
                ownProgram.ReadOnly = true;
                executeBoard.Visible = false;
            }
            else
            {
                saveProgram.Visible = true;
                ownProgram.ReadOnly = false;
                executeBoard.Visible = true;
            }
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

        private bool programChanged()
        {
            if (ownProgram.Text == "") return false;
            if (ownProgram.ReadOnly) return false;
            if (ownProgram.Text != string.Join(Environment.NewLine, originalCommands))
            {
                DialogResult result = MessageBox.Show("Are you sure? there are unsaved changes", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) return false;
                else return true;
            }
            else return false;
        }

        private void save()
        {
            if (executionWay.Text == "Import")
            {
                file = filePathInput.Text;
                File.WriteAllText(file, ownProgram.Text);
                List<string> newCommands = File.ReadAllLines(file).ToList();
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
                    executionWay.SelectedIndexChanged -= new EventHandler(executionWay_SelectedIndexChanged);
                    filePathInput.Visible = true;
                    executionWay.Text = "Import";
                    executionWay.SelectedIndexChanged += new EventHandler(executionWay_SelectedIndexChanged);
                    ownProgram.Text = string.Join(Environment.NewLine, File.ReadAllText(file));
                    filePathInput.Text = file;
                }
                else
                {
                    MessageBox.Show("The file must have a name");
                }
            }
        }

        private void saveProgram_clicked(object sender, EventArgs e)
        {
            save();
        }
    }
}


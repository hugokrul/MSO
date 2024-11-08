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
using System.Diagnostics.CodeAnalysis;

namespace MSO3
{
    [ExcludeFromCodeCoverage]
    public partial class Sandbox : BaseForm
    {
        private string? file;
        private List<string> originalCommands = [];
        private string? previousExecutionWay;
        private Board board = new(10, 10);
        private static Sandbox? instance;

        private Sandbox() : base()
        {
            InitializeComponent();
        }

        // used for the singleton pattern
        public static Sandbox GetInstance()
        {
            if (instance == null)
            {
                instance = new Sandbox();
            }
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        // paints the board
        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen whitePen = new(Color.White, 1);

            Drawer.DrawBoard((Panel)sender, g, whitePen, board);
        }

        // shows the metrics of the program, this function cannot be pulled up to CaclulateMetrics, because it has to show the MessageBox.
        public static void ShowMetrics(string[] commands)
        {
            CalculateMetrics.calculateMetrics(commands);
            MessageBox.Show(
                    $"Number of commands: {CalculateMetrics.NumberOfCommands}\n" +
                    $"Nesting level: {CalculateMetrics.NestingLevel}\n" +
                    $"Number of Repeats: {CalculateMetrics.NumberOfRepeat}"
                );
        }

        // gives back the list with string commands when a specific choice is given
        // returns [] if an incorrect choice is given
        public List<string> ChosenProgram(string? choice)
        {
            switch (choice)
            {
                case "Basic":
                    return MSO2.Program.AvailablePrograms[0].Skip(1).ToList();
                case "Hard":
                    return MSO2.Program.AvailablePrograms[1].Skip(1).ToList();
                case "Advanced":
                    return MSO2.Program.AvailablePrograms[2].Skip(1).ToList();
                case "Import":
                    return RunImportedProgram();
                case "Write your own":
                    ownProgram.ReadOnly = false;
                    return ownProgram.Text.Split('\n').ToList();
            }
            return new List<string>();
        }

        // gives back the string command of a specified filepath
        private List<string> RunImportedProgram()
        {
            if (file != null && ownProgram.Text != "")
            {
                Save();
            }
            string path = filePathInput.Text;
            file = path;
            List<string> result = File.ReadAllLines(path).ToList();
            return result;
        }

        // shows or hides buttons depending on the executionway
        public void UpdateButtons(string input)
        {
            if (input == "Import")
            {
                FileExistence();
                filePathInput.Visible = true;
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

        // if the program is changed, it warns the user, if says they want to go back, the last executionway is retrieved
        private void ExecutionWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ProgramChanged())
            {
                ownProgram.Text = "";

                string input = executionWay.Text;
                previousExecutionWay = input;
                UpdateButtons(input);
            }
            else
            {
                executionWay.SelectedIndexChanged -= new EventHandler(ExecutionWay_SelectedIndexChanged);
                executionWay.Text = previousExecutionWay;
                executionWay.SelectedIndexChanged += new EventHandler(ExecutionWay_SelectedIndexChanged);
            }
        }

        private void FilePathInput_TextChanged(object sender, EventArgs e)
        {
            FileExistence();
        }

        // checks if a file exists and updates those buttons
        private void FileExistence()
        {
            if (ImportFile.CheckExistence(filePathInput.Text))
            {
                saveProgram.Visible = true;
                ownProgram.ReadOnly = false;
                executeBoard.Visible = true;
            }
            else
            {
                saveProgram.Visible = false;
                ownProgram.ReadOnly = true;
                executeBoard.Visible = false;
            }
        }

        // executes when opening this page
        private void Sandbox_Load(object sender, EventArgs e)
        {
            board = new Board(10, 10);
            file = null;
            Text = $"Robologic {board.Name}";
            switch (board.Name)
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

        // checks if the program is changed by comparing the current program to the last saved program. (originalCommands)
        public bool ProgramChanged()
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

        // saves the text with a specified way of execution
        // it also updates the last save program (original commands)
        private void Save()
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
                    file = ImportFile.ExportWriteYourOwn(name, ownProgram.Text);
                    executionWay.SelectedIndexChanged -= new EventHandler(ExecutionWay_SelectedIndexChanged);
                    filePathInput.Visible = true;
                    executionWay.Text = "Import";
                    executionWay.SelectedIndexChanged += new EventHandler(ExecutionWay_SelectedIndexChanged);
                    ownProgram.Text = string.Join(Environment.NewLine, File.ReadAllText(file));
                    filePathInput.Text = file;
                }
                else
                {
                    MessageBox.Show("The file must have a name");
                }
            }
        }

        // goes back to the homepage
        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (!ProgramChanged())
            {
                Home homePage = Home.GetInstance();
                homePage.StartPosition = FormStartPosition.CenterScreen;
                homePage.Show();
                this.Hide();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        // executes the board
        private async void executeBoard_Click_1(object sender, EventArgs e)
        {
            board = new Board(10, 10);
            string? difficulty = executionWay.GetItemText(executionWay.SelectedItem);
            originalCommands = ChosenProgram(difficulty);
            List<ICommand> commands = CommandParser.Parse(originalCommands.ToArray());

            if (file != null) board.Name = Path.GetFileName(file);

            board.PlayBoard(commands);

            boardPanel.Invalidate();
            this.Text = $"Robologic {board.Name}";

            if (executionWay.Text != "Write your own") ownProgram.Text = string.Join(Environment.NewLine, originalCommands);

        }

        private void CalculateMetricsButton_Click(object sender, EventArgs e)
        {
            ShowMetrics([.. originalCommands]);
        }
    }
}


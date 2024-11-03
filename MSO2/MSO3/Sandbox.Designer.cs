namespace MSO3
{
    partial class Sandbox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sandbox));
            pageNameSandbox = new Label();
            boardPanel = new Panel();
            executionWay = new ComboBox();
            filePathInput = new TextBox();
            ownProgram = new TextBox();
            HomeButton = new Button();
            saveProgram = new Button();
            executeBoard = new Button();
            chooseaprogram = new Label();
            SuspendLayout();
            // 
            // pageNameSandbox
            // 
            pageNameSandbox.AutoSize = true;
            pageNameSandbox.BackColor = Color.Transparent;
            pageNameSandbox.Font = new Font("Showcard Gothic", 24F, FontStyle.Italic);
            pageNameSandbox.ForeColor = Color.White;
            pageNameSandbox.Location = new Point(300, -3);
            pageNameSandbox.Name = "pageNameSandbox";
            pageNameSandbox.Size = new Size(205, 50);
            pageNameSandbox.TabIndex = 2;
            pageNameSandbox.Text = "Sandbox";
            // 
            // boardPanel
            // 
            boardPanel.BackColor = Color.FromArgb(108, 92, 231);
            boardPanel.Location = new Point(253, 50);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(400, 400);
            boardPanel.TabIndex = 3;
            boardPanel.Paint += BoardPanel_Paint;
            // 
            // executionWay
            // 
            executionWay.BackColor = Color.FromArgb(9, 132, 227);
            executionWay.DropDownStyle = ComboBoxStyle.DropDownList;
            executionWay.FlatStyle = FlatStyle.Popup;
            executionWay.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            executionWay.ForeColor = Color.White;
            executionWay.FormattingEnabled = true;
            executionWay.Items.AddRange(new object[] { "Basic", "Hard", "Advanced", "Import", "Write your own" });
            executionWay.Location = new Point(24, 50);
            executionWay.Name = "executionWay";
            executionWay.Size = new Size(223, 27);
            executionWay.TabIndex = 5;
            executionWay.SelectedIndexChanged += ExecutionWay_SelectedIndexChanged;
            // 
            // filePathInput
            // 
            filePathInput.BackColor = Color.FromArgb(9, 132, 227);
            filePathInput.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filePathInput.ForeColor = Color.White;
            filePathInput.Location = new Point(24, 83);
            filePathInput.Name = "filePathInput";
            filePathInput.Size = new Size(223, 27);
            filePathInput.TabIndex = 6;
            filePathInput.Text = "full path...";
            filePathInput.Visible = false;
            filePathInput.TextChanged += FilePathInput_TextChanged;
            // 
            // ownProgram
            // 
            ownProgram.BackColor = Color.FromArgb(9, 132, 227);
            ownProgram.Font = new Font("Showcard Gothic", 9F);
            ownProgram.ForeColor = Color.White;
            ownProgram.Location = new Point(24, 126);
            ownProgram.Multiline = true;
            ownProgram.Name = "ownProgram";
            ownProgram.ReadOnly = true;
            ownProgram.ScrollBars = ScrollBars.Vertical;
            ownProgram.Size = new Size(223, 312);
            ownProgram.TabIndex = 7;
            // 
            // HomeButton
            // 
            HomeButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            HomeButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeButton.ForeColor = Color.FromArgb(223, 230, 233);
            HomeButton.Location = new Point(669, 50);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(119, 47);
            HomeButton.TabIndex = 8;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // saveProgram
            // 
            saveProgram.BackgroundImage = Properties.Resources.gradient_img__7_;
            saveProgram.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveProgram.ForeColor = Color.FromArgb(223, 230, 233);
            saveProgram.Location = new Point(669, 103);
            saveProgram.Name = "saveProgram";
            saveProgram.Size = new Size(119, 47);
            saveProgram.TabIndex = 9;
            saveProgram.Text = "Save";
            saveProgram.UseVisualStyleBackColor = true;
            saveProgram.Click += SaveButton_Click;
            // 
            // executeBoard
            // 
            executeBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            executeBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            executeBoard.ForeColor = Color.FromArgb(223, 230, 233);
            executeBoard.Location = new Point(669, 391);
            executeBoard.Name = "executeBoard";
            executeBoard.Size = new Size(119, 47);
            executeBoard.TabIndex = 10;
            executeBoard.Text = "Run";
            executeBoard.UseVisualStyleBackColor = true;
            executeBoard.Click += executeBoard_Click_1;
            // 
            // chooseaprogram
            // 
            chooseaprogram.AutoSize = true;
            chooseaprogram.BackColor = Color.Transparent;
            chooseaprogram.Font = new Font("Showcard Gothic", 10F, FontStyle.Italic);
            chooseaprogram.ForeColor = Color.White;
            chooseaprogram.Location = new Point(24, 26);
            chooseaprogram.Name = "chooseaprogram";
            chooseaprogram.Size = new Size(182, 21);
            chooseaprogram.TabIndex = 11;
            chooseaprogram.Text = "Choose a program!";
            // 
            // Sandbox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gradient_img__7_;
            ClientSize = new Size(800, 450);
            Controls.Add(chooseaprogram);
            Controls.Add(executeBoard);
            Controls.Add(saveProgram);
            Controls.Add(HomeButton);
            Controls.Add(pageNameSandbox);
            Controls.Add(ownProgram);
            Controls.Add(filePathInput);
            Controls.Add(executionWay);
            Controls.Add(boardPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Sandbox";
            Load += Sandbox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label pageNameSandbox;
        private Panel boardPanel;
        private Button executeBoard;
        private ComboBox executionWay;
        private TextBox filePathInput;
        private TextBox ownProgram;
        private Button HomeButton;
        private Button saveProgram;
        private Label chooseaprogram;
    }
}
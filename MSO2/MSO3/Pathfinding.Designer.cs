namespace MSO3
{
    partial class Pathfinding
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
            CalculateMetricsButton = new Button();
            ExecuteBoard = new Button();
            checkBoard = new Button();
            importBoard = new Button();
            HomeButton = new Button();
            pageNamePathfinding = new Label();
            ownProgram = new TextBox();
            boardPanel = new Panel();
            SuspendLayout();
            // 
            // CalculateMetricsButton
            // 
            CalculateMetricsButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            CalculateMetricsButton.Font = new Font("Snap ITC", 12.2F);
            CalculateMetricsButton.ForeColor = Color.FromArgb(223, 230, 233);
            CalculateMetricsButton.Location = new Point(669, 332);
            CalculateMetricsButton.Name = "CalculateMetricsButton";
            CalculateMetricsButton.Size = new Size(119, 47);
            CalculateMetricsButton.TabIndex = 24;
            CalculateMetricsButton.Text = "Metrics";
            CalculateMetricsButton.UseVisualStyleBackColor = true;
            CalculateMetricsButton.Click += CalculateMetricsButton_Click;
            // 
            // ExecuteBoard
            // 
            ExecuteBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            ExecuteBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExecuteBoard.ForeColor = Color.FromArgb(223, 230, 233);
            ExecuteBoard.Location = new Point(669, 385);
            ExecuteBoard.Name = "ExecuteBoard";
            ExecuteBoard.Size = new Size(119, 47);
            ExecuteBoard.TabIndex = 23;
            ExecuteBoard.Text = "Run";
            ExecuteBoard.UseVisualStyleBackColor = true;
            ExecuteBoard.Click += ExecuteBoard_Click;
            // 
            // checkBoard
            // 
            checkBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            checkBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoard.ForeColor = Color.FromArgb(223, 230, 233);
            checkBoard.Location = new Point(669, 157);
            checkBoard.Name = "checkBoard";
            checkBoard.Size = new Size(119, 47);
            checkBoard.TabIndex = 22;
            checkBoard.Text = "Check";
            checkBoard.UseVisualStyleBackColor = true;
            checkBoard.Click += checkBoard_Click;
            // 
            // importBoard
            // 
            importBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            importBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importBoard.ForeColor = Color.FromArgb(223, 230, 233);
            importBoard.Location = new Point(669, 104);
            importBoard.Name = "importBoard";
            importBoard.Size = new Size(119, 47);
            importBoard.TabIndex = 21;
            importBoard.Text = "Board";
            importBoard.UseVisualStyleBackColor = true;
            importBoard.Click += importBoard_Click;
            // 
            // HomeButton
            // 
            HomeButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            HomeButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeButton.ForeColor = Color.FromArgb(223, 230, 233);
            HomeButton.Location = new Point(669, 51);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(119, 47);
            HomeButton.TabIndex = 20;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // pageNamePathfinding
            // 
            pageNamePathfinding.AutoSize = true;
            pageNamePathfinding.BackColor = Color.Transparent;
            pageNamePathfinding.Font = new Font("Showcard Gothic", 24F, FontStyle.Italic);
            pageNamePathfinding.ForeColor = Color.White;
            pageNamePathfinding.Location = new Point(254, -2);
            pageNamePathfinding.Name = "pageNamePathfinding";
            pageNamePathfinding.Size = new Size(286, 50);
            pageNamePathfinding.TabIndex = 19;
            pageNamePathfinding.Text = "Pathfinding";
            // 
            // ownProgram
            // 
            ownProgram.BackColor = Color.FromArgb(9, 132, 227);
            ownProgram.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ownProgram.ForeColor = Color.White;
            ownProgram.Location = new Point(12, 51);
            ownProgram.Multiline = true;
            ownProgram.Name = "ownProgram";
            ownProgram.ScrollBars = ScrollBars.Vertical;
            ownProgram.Size = new Size(223, 391);
            ownProgram.TabIndex = 18;
            // 
            // boardPanel
            // 
            boardPanel.BackColor = Color.FromArgb(108, 92, 231);
            boardPanel.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boardPanel.ForeColor = Color.White;
            boardPanel.Location = new Point(254, 51);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(400, 400);
            boardPanel.TabIndex = 17;
            boardPanel.Paint += boardPanel_Paint;
            // 
            // Pathfinding
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gradient_img__7_;
            ClientSize = new Size(800, 450);
            Controls.Add(CalculateMetricsButton);
            Controls.Add(ExecuteBoard);
            Controls.Add(checkBoard);
            Controls.Add(importBoard);
            Controls.Add(HomeButton);
            Controls.Add(pageNamePathfinding);
            Controls.Add(ownProgram);
            Controls.Add(boardPanel);
            Name = "Pathfinding";
            Text = "Pathfinding";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CalculateMetricsButton;
        private Button ExecuteBoard;
        private Button checkBoard;
        private Button importBoard;
        private Button HomeButton;
        private Label pageNamePathfinding;
        private TextBox ownProgram;
        private Panel boardPanel;
    }
}
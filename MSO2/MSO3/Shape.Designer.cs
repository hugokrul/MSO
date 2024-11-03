namespace MSO3
{
    partial class Shape
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shape));
            boardPanel = new Panel();
            ownProgram = new TextBox();
            pageNameShape = new Label();
            HomeButton = new Button();
            importBoard = new Button();
            checkBoard = new Button();
            ExecuteBoard = new Button();
            SuspendLayout();
            // 
            // boardPanel
            // 
            boardPanel.BackColor = Color.FromArgb(108, 92, 231);
            boardPanel.Font = new Font("Snap ITC", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boardPanel.ForeColor = Color.White;
            boardPanel.Location = new Point(254, 47);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(400, 400);
            boardPanel.TabIndex = 4;
            boardPanel.Paint += BoardPanel_Paint;
            // 
            // ownProgram
            // 
            ownProgram.BackColor = Color.FromArgb(9, 132, 227);
            ownProgram.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ownProgram.ForeColor = Color.White;
            ownProgram.Location = new Point(12, 47);
            ownProgram.Multiline = true;
            ownProgram.Name = "ownProgram";
            ownProgram.ScrollBars = ScrollBars.Vertical;
            ownProgram.Size = new Size(223, 391);
            ownProgram.TabIndex = 9;
            // 
            // pageNameShape
            // 
            pageNameShape.AutoSize = true;
            pageNameShape.BackColor = Color.Transparent;
            pageNameShape.Font = new Font("Showcard Gothic", 24F, FontStyle.Italic);
            pageNameShape.ForeColor = Color.White;
            pageNameShape.Location = new Point(310, -4);
            pageNameShape.Name = "pageNameShape";
            pageNameShape.Size = new Size(148, 50);
            pageNameShape.TabIndex = 11;
            pageNameShape.Text = "Shape";
            // 
            // HomeButton
            // 
            HomeButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            HomeButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            HomeButton.ForeColor = Color.FromArgb(223, 230, 233);
            HomeButton.Location = new Point(669, 47);
            HomeButton.Name = "HomeButton";
            HomeButton.Size = new Size(119, 47);
            HomeButton.TabIndex = 12;
            HomeButton.Text = "Home";
            HomeButton.UseVisualStyleBackColor = true;
            HomeButton.Click += HomeButton_Click;
            // 
            // importBoard
            // 
            importBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            importBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            importBoard.ForeColor = Color.FromArgb(223, 230, 233);
            importBoard.Location = new Point(669, 100);
            importBoard.Name = "importBoard";
            importBoard.Size = new Size(119, 47);
            importBoard.TabIndex = 13;
            importBoard.Text = "Board";
            importBoard.UseVisualStyleBackColor = true;
            importBoard.Click += importBoard_Click_1;
            // 
            // checkBoard
            // 
            checkBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            checkBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoard.ForeColor = Color.FromArgb(223, 230, 233);
            checkBoard.Location = new Point(669, 153);
            checkBoard.Name = "checkBoard";
            checkBoard.Size = new Size(119, 47);
            checkBoard.TabIndex = 14;
            checkBoard.Text = "Check";
            checkBoard.UseVisualStyleBackColor = true;
            checkBoard.Click += checkBoard_Click;
            // 
            // ExecuteBoard
            // 
            ExecuteBoard.BackgroundImage = Properties.Resources.gradient_img__7_;
            ExecuteBoard.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExecuteBoard.ForeColor = Color.FromArgb(223, 230, 233);
            ExecuteBoard.Location = new Point(669, 381);
            ExecuteBoard.Name = "ExecuteBoard";
            ExecuteBoard.Size = new Size(119, 47);
            ExecuteBoard.TabIndex = 15;
            ExecuteBoard.Text = "Run";
            ExecuteBoard.UseVisualStyleBackColor = true;
            ExecuteBoard.Click += ExecuteBoard_Click_1;
            // 
            // Shape
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gradient_img__7_;
            ClientSize = new Size(800, 450);
            Controls.Add(ExecuteBoard);
            Controls.Add(checkBoard);
            Controls.Add(importBoard);
            Controls.Add(HomeButton);
            Controls.Add(pageNameShape);
            Controls.Add(ownProgram);
            Controls.Add(boardPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Shape";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel boardPanel;
        private Button importBoard;
        private TextBox ownProgram;
        private Button checkShape;
        private Label pageNameShape;
        private Button HomeButton;
        private Button button1;
        private Button checkBoard;
        private Button ExecuteBoard;
    }
}
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
            homePage = new Button();
            pageNameShape = new Label();
            boardPanel = new Panel();
            ExecuteBoard = new Button();
            importBoard = new Button();
            ownProgram = new TextBox();
            checkShape = new Button();
            SuspendLayout();
            // 
            // homePage
            // 
            homePage.Location = new Point(694, 12);
            homePage.Name = "homePage";
            homePage.Size = new Size(94, 29);
            homePage.TabIndex = 0;
            homePage.Text = "Home";
            homePage.UseVisualStyleBackColor = true;
            homePage.Click += HomePage_Click;
            // 
            // pageNameShape
            // 
            pageNameShape.AutoSize = true;
            pageNameShape.Location = new Point(12, 9);
            pageNameShape.Name = "pageNameShape";
            pageNameShape.Size = new Size(50, 20);
            pageNameShape.TabIndex = 2;
            pageNameShape.Text = "Shape";
            // 
            // boardPanel
            // 
            boardPanel.Location = new Point(259, 38);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(400, 400);
            boardPanel.TabIndex = 4;
            boardPanel.Paint += BoardPanel_Paint;
            // 
            // ExecuteBoard
            // 
            ExecuteBoard.Location = new Point(694, 400);
            ExecuteBoard.Name = "ExecuteBoard";
            ExecuteBoard.Size = new Size(94, 29);
            ExecuteBoard.TabIndex = 5;
            ExecuteBoard.Text = "Execute";
            ExecuteBoard.UseVisualStyleBackColor = true;
            ExecuteBoard.Click += ExecuteBoard_Click;
            // 
            // importBoard
            // 
            importBoard.Location = new Point(694, 47);
            importBoard.Name = "importBoard";
            importBoard.Size = new Size(94, 29);
            importBoard.TabIndex = 6;
            importBoard.Text = "Board";
            importBoard.TextImageRelation = TextImageRelation.ImageBeforeText;
            importBoard.UseVisualStyleBackColor = true;
            importBoard.Click += ImportBoard_Click;
            // 
            // ownProgram
            // 
            ownProgram.Location = new Point(12, 38);
            ownProgram.Multiline = true;
            ownProgram.Name = "ownProgram";
            ownProgram.ScrollBars = ScrollBars.Vertical;
            ownProgram.Size = new Size(223, 391);
            ownProgram.TabIndex = 9;
            // 
            // checkShape
            // 
            checkShape.Location = new Point(694, 82);
            checkShape.Name = "checkShape";
            checkShape.Size = new Size(94, 29);
            checkShape.TabIndex = 10;
            checkShape.Text = "Check";
            checkShape.UseVisualStyleBackColor = true;
            checkShape.Click += CheckShape_Click;
            // 
            // Shape
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkShape);
            Controls.Add(ownProgram);
            Controls.Add(importBoard);
            Controls.Add(ExecuteBoard);
            Controls.Add(boardPanel);
            Controls.Add(pageNameShape);
            Controls.Add(homePage);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Shape";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button homePage;
        private Label pageNameShape;
        private Panel boardPanel;
        private Button ExecuteBoard;
        private Button importBoard;
        private TextBox ownProgram;
        private Button checkShape;
    }
}
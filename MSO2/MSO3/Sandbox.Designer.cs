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
            homeNav = new Button();
            pageNameSandbox = new Label();
            boardPanel = new Panel();
            executeBoard = new Button();
            executionWay = new ComboBox();
            SuspendLayout();
            // 
            // homeNav
            // 
            homeNav.Location = new Point(694, 12);
            homeNav.Name = "homeNav";
            homeNav.Size = new Size(94, 29);
            homeNav.TabIndex = 0;
            homeNav.Text = "Home";
            homeNav.UseVisualStyleBackColor = true;
            homeNav.Click += homeNav_Click;
            // 
            // pageNameSandbox
            // 
            pageNameSandbox.AutoSize = true;
            pageNameSandbox.Location = new Point(12, 9);
            pageNameSandbox.Name = "pageNameSandbox";
            pageNameSandbox.Size = new Size(67, 20);
            pageNameSandbox.TabIndex = 2;
            pageNameSandbox.Text = "Sandbox";
            // 
            // boardPanel
            // 
            boardPanel.Location = new Point(259, 38);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(400, 400);
            boardPanel.TabIndex = 3;
            boardPanel.Paint += boardPanel_Paint;
            // 
            // executeBoard
            // 
            executeBoard.Location = new Point(694, 400);
            executeBoard.Name = "executeBoard";
            executeBoard.Size = new Size(94, 29);
            executeBoard.TabIndex = 4;
            executeBoard.Text = "Run";
            executeBoard.UseVisualStyleBackColor = true;
            executeBoard.Click += executeBoard_Click;
            // 
            // executionWay
            // 
            executionWay.FormattingEnabled = true;
            executionWay.Items.AddRange(new object[] { "Basic", "Hard", "Advanced" });
            executionWay.Location = new Point(12, 38);
            executionWay.Name = "executionWay";
            executionWay.Size = new Size(151, 28);
            executionWay.TabIndex = 5;
            executionWay.Text = "Basic";
            // 
            // Sandbox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(executionWay);
            Controls.Add(executeBoard);
            Controls.Add(boardPanel);
            Controls.Add(pageNameSandbox);
            Controls.Add(homeNav);
            Name = "Sandbox";
            Text = "Sandbox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button homeNav;
        private Label pageNameSandbox;
        private Panel boardPanel;
        private Button executeBoard;
        private ComboBox executionWay;
    }
}
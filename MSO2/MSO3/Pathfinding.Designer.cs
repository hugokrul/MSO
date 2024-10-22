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
            homePage = new Button();
            pageNamePathfinding = new Label();
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
            homePage.Click += homePage_Click;
            // 
            // pageNamePathfinding
            // 
            pageNamePathfinding.AutoSize = true;
            pageNamePathfinding.Location = new Point(12, 9);
            pageNamePathfinding.Name = "pageNamePathfinding";
            pageNamePathfinding.Size = new Size(84, 20);
            pageNamePathfinding.TabIndex = 1;
            pageNamePathfinding.Text = "Pathfinding";
            pageNamePathfinding.Click += pageNamePathfinding_Click;
            // 
            // Pathfinding
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pageNamePathfinding);
            Controls.Add(homePage);
            Name = "Pathfinding";
            Text = "Pathfinding";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button homePage;
        private Label pageNamePathfinding;
    }
}
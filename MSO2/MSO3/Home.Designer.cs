namespace MSO3
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            sandboxNav = new Button();
            shapePage = new Button();
            pageNameHome = new Label();
            SuspendLayout();
            // 
            // sandboxNav
            // 
            sandboxNav.Location = new Point(694, 9);
            sandboxNav.Name = "sandboxNav";
            sandboxNav.Size = new Size(94, 29);
            sandboxNav.TabIndex = 0;
            sandboxNav.Text = "Sandbox";
            sandboxNav.UseVisualStyleBackColor = true;
            sandboxNav.Click += sandboxNav_Click;
            // 
            // shapePage
            // 
            shapePage.Location = new Point(694, 47);
            shapePage.Name = "shapePage";
            shapePage.Size = new Size(94, 29);
            shapePage.TabIndex = 1;
            shapePage.Text = "Shape";
            shapePage.UseVisualStyleBackColor = true;
            shapePage.Click += shapePage_Click;
            // 
            // pageNameHome
            // 
            pageNameHome.AutoSize = true;
            pageNameHome.Location = new Point(12, 9);
            pageNameHome.Name = "pageNameHome";
            pageNameHome.Size = new Size(50, 20);
            pageNameHome.TabIndex = 3;
            pageNameHome.Text = "Home";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pageNameHome);
            Controls.Add(shapePage);
            Controls.Add(sandboxNav);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sandboxNav;
        private Button shapePage;
        private Label pageNameHome;
    }
}

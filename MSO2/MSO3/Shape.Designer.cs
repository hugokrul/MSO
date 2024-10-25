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
            // pageNameShape
            // 
            pageNameShape.AutoSize = true;
            pageNameShape.Location = new Point(12, 9);
            pageNameShape.Name = "pageNameShape";
            pageNameShape.Size = new Size(50, 20);
            pageNameShape.TabIndex = 2;
            pageNameShape.Text = "Shape";
            // 
            // Shape
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
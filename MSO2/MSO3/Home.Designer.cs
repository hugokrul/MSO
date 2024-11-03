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
            labelRoboLogic = new Label();
            PlayButton = new Button();
            QuitButton = new Button();
            SuspendLayout();
            // 
            // labelRoboLogic
            // 
            labelRoboLogic.AutoSize = true;
            labelRoboLogic.BackColor = Color.Transparent;
            labelRoboLogic.Font = new Font("Showcard Gothic", 24F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelRoboLogic.ForeColor = Color.FromArgb(223, 230, 233);
            labelRoboLogic.Location = new Point(263, 25);
            labelRoboLogic.Name = "labelRoboLogic";
            labelRoboLogic.Size = new Size(246, 50);
            labelRoboLogic.TabIndex = 4;
            labelRoboLogic.Text = "RoboLogic";
            // 
            // PlayButton
            // 
            PlayButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            PlayButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayButton.ForeColor = Color.FromArgb(223, 230, 233);
            PlayButton.Location = new Point(301, 161);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(172, 54);
            PlayButton.TabIndex = 5;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // QuitButton
            // 
            QuitButton.BackgroundImage = Properties.Resources.gradient_img__7_;
            QuitButton.Font = new Font("Snap ITC", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuitButton.ForeColor = Color.FromArgb(223, 230, 233);
            QuitButton.Location = new Point(301, 243);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(172, 54);
            QuitButton.TabIndex = 6;
            QuitButton.Text = "Quit";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += button1_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.gradient_img__7_;
            ClientSize = new Size(800, 450);
            Controls.Add(QuitButton);
            Controls.Add(PlayButton);
            Controls.Add(labelRoboLogic);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Home";
            Load += Home_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelRoboLogic;
        private Button PlayButton;
        private Button QuitButton;
    }
}

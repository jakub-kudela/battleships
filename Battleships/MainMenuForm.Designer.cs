namespace Battleships
{
    partial class MainMenuForm
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
            System.Windows.Forms.Label copyrightLabel;
            System.Windows.Forms.PictureBox menuPictureBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.quitButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.creditsButton = new System.Windows.Forms.Button();
            this.multiplayerButton = new System.Windows.Forms.Button();
            this.singleplayerButton = new System.Windows.Forms.Button();
            this.menuGroupBox = new System.Windows.Forms.GroupBox();
            copyrightLabel = new System.Windows.Forms.Label();
            menuPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(menuPictureBox)).BeginInit();
            this.menuGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            copyrightLabel.Location = new System.Drawing.Point(357, 499);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new System.Drawing.Size(115, 14);
            copyrightLabel.TabIndex = 13;
            copyrightLabel.Text = "© Jakub Kúdela, 2010 ";
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(6, 107);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(448, 40);
            this.quitButton.TabIndex = 12;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.QuitButtonClick);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(233, 61);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(221, 40);
            this.aboutButton.TabIndex = 11;
            this.aboutButton.Text = "About (Wikipedia)";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.AboutButtonClick);
            // 
            // creditsButton
            // 
            this.creditsButton.Location = new System.Drawing.Point(6, 61);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(221, 40);
            this.creditsButton.TabIndex = 10;
            this.creditsButton.Text = "Credits";
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.CreditsButtonClick);
            // 
            // multiplayerButton
            // 
            this.multiplayerButton.Location = new System.Drawing.Point(233, 12);
            this.multiplayerButton.Name = "multiplayerButton";
            this.multiplayerButton.Size = new System.Drawing.Size(221, 43);
            this.multiplayerButton.TabIndex = 9;
            this.multiplayerButton.Text = "Multiplayer New Game";
            this.multiplayerButton.UseVisualStyleBackColor = true;
            this.multiplayerButton.Click += new System.EventHandler(this.MultiplayerButtonClick);
            // 
            // singleplayerButton
            // 
            this.singleplayerButton.Location = new System.Drawing.Point(6, 12);
            this.singleplayerButton.Name = "singleplayerButton";
            this.singleplayerButton.Size = new System.Drawing.Size(221, 43);
            this.singleplayerButton.TabIndex = 8;
            this.singleplayerButton.Text = "Singleplayer New Game";
            this.singleplayerButton.UseVisualStyleBackColor = true;
            this.singleplayerButton.Click += new System.EventHandler(this.SingleplayerButtonClick);
            // 
            // menuPictureBox
            // 
            menuPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            menuPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("menuPictureBox.Image")));
            menuPictureBox.Location = new System.Drawing.Point(12, 18);
            menuPictureBox.Name = "menuPictureBox";
            menuPictureBox.Size = new System.Drawing.Size(460, 332);
            menuPictureBox.TabIndex = 7;
            menuPictureBox.TabStop = false;
            // 
            // menuGroupBox
            // 
            this.menuGroupBox.Controls.Add(this.singleplayerButton);
            this.menuGroupBox.Controls.Add(this.multiplayerButton);
            this.menuGroupBox.Controls.Add(this.quitButton);
            this.menuGroupBox.Controls.Add(this.aboutButton);
            this.menuGroupBox.Controls.Add(this.creditsButton);
            this.menuGroupBox.Location = new System.Drawing.Point(12, 344);
            this.menuGroupBox.Name = "menuGroupBox";
            this.menuGroupBox.Size = new System.Drawing.Size(460, 152);
            this.menuGroupBox.TabIndex = 14;
            this.menuGroupBox.TabStop = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 516);
            this.Controls.Add(this.menuGroupBox);
            this.Controls.Add(copyrightLabel);
            this.Controls.Add(menuPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenuForm";
            this.Text = "Battleships: Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuFormClosing);
            ((System.ComponentModel.ISupportInitialize)(menuPictureBox)).EndInit();
            this.menuGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button creditsButton;
        private System.Windows.Forms.Button multiplayerButton;
        private System.Windows.Forms.Button singleplayerButton;
        private System.Windows.Forms.GroupBox menuGroupBox;
    }
}


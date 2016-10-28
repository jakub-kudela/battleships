namespace Battleships
{
    partial class CreditsForm
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
            System.Windows.Forms.PictureBox creditsPictureBox;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsForm));
            this.creditsLabel = new System.Windows.Forms.Label();
            this.creditsButton = new System.Windows.Forms.Button();
            creditsPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(creditsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // creditsPictureBox
            // 
            creditsPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            creditsPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("creditsPictureBox.Image")));
            creditsPictureBox.Location = new System.Drawing.Point(12, 18);
            creditsPictureBox.Name = "creditsPictureBox";
            creditsPictureBox.Size = new System.Drawing.Size(460, 332);
            creditsPictureBox.TabIndex = 8;
            creditsPictureBox.TabStop = false;
            // 
            // creditsLabel
            // 
            this.creditsLabel.AutoSize = true;
            this.creditsLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            this.creditsLabel.Location = new System.Drawing.Point(12, 363);
            this.creditsLabel.Name = "creditsLabel";
            this.creditsLabel.Size = new System.Drawing.Size(49, 14);
            this.creditsLabel.TabIndex = 15;
            this.creditsLabel.Text = "CREDITS";
            // 
            // creditsButton
            // 
            this.creditsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("creditsButton.BackgroundImage")));
            this.creditsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.creditsButton.Location = new System.Drawing.Point(184, 363);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(288, 43);
            this.creditsButton.TabIndex = 16;
            this.creditsButton.UseVisualStyleBackColor = true;
            this.creditsButton.Click += new System.EventHandler(this.CreditsButtonClick);
            // 
            // CreditsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 418);
            this.Controls.Add(this.creditsButton);
            this.Controls.Add(this.creditsLabel);
            this.Controls.Add(creditsPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreditsForm";
            this.Text = "Battleships: Credits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreditsFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(creditsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label creditsLabel;
        private System.Windows.Forms.Button creditsButton;
    }
}
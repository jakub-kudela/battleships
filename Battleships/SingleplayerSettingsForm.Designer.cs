namespace Battleships
{
    partial class SingleplayerSettingsForm
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
            System.Windows.Forms.Label nameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleplayerSettingsForm));
            System.Windows.Forms.GroupBox settingsGroupBox;
            this.okButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            copyrightLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            settingsGroupBox = new System.Windows.Forms.GroupBox();
            settingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            copyrightLabel.Location = new System.Drawing.Point(157, 108);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new System.Drawing.Size(115, 14);
            copyrightLabel.TabIndex = 16;
            copyrightLabel.Text = "© Jakub Kúdela, 2010 ";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(6, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 2;
            nameLabel.Text = "Name:";
            // 
            // okButton
            // 
            this.okButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("okButton.BackgroundImage")));
            this.okButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.okButton.Location = new System.Drawing.Point(6, 45);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(248, 43);
            this.okButton.TabIndex = 0;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // settingsGroupBox
            // 
            settingsGroupBox.Controls.Add(nameLabel);
            settingsGroupBox.Controls.Add(this.okButton);
            settingsGroupBox.Controls.Add(this.nameTextBox);
            settingsGroupBox.Location = new System.Drawing.Point(12, 12);
            settingsGroupBox.Name = "settingsGroupBox";
            settingsGroupBox.Size = new System.Drawing.Size(260, 93);
            settingsGroupBox.TabIndex = 15;
            settingsGroupBox.TabStop = false;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(50, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(204, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // SingleplayerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 125);
            this.Controls.Add(copyrightLabel);
            this.Controls.Add(settingsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SingleplayerSettingsForm";
            this.Text = "Battleships: Set Player’s name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleplayerSettingsFormClosing);
            this.Enter += new System.EventHandler(this.SingleplayerSettingsFormEnter);
            settingsGroupBox.ResumeLayout(false);
            settingsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox nameTextBox;
    }
}
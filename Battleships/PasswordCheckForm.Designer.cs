namespace Battleships
{
    partial class PasswordCheckForm
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
            System.Windows.Forms.GroupBox passwordGroupBox;
            System.Windows.Forms.Label passwordLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordCheckForm));
            this.okButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            copyrightLabel = new System.Windows.Forms.Label();
            passwordGroupBox = new System.Windows.Forms.GroupBox();
            passwordLabel = new System.Windows.Forms.Label();
            passwordGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Font = new System.Drawing.Font("Arial", 8.25F);
            copyrightLabel.Location = new System.Drawing.Point(157, 108);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new System.Drawing.Size(115, 14);
            copyrightLabel.TabIndex = 18;
            copyrightLabel.Text = "© Jakub Kúdela, 2010 ";
            // 
            // passwordGroupBox
            // 
            passwordGroupBox.Controls.Add(passwordLabel);
            passwordGroupBox.Controls.Add(this.okButton);
            passwordGroupBox.Controls.Add(this.passwordTextBox);
            passwordGroupBox.Location = new System.Drawing.Point(12, 12);
            passwordGroupBox.Name = "passwordGroupBox";
            passwordGroupBox.Size = new System.Drawing.Size(260, 93);
            passwordGroupBox.TabIndex = 17;
            passwordGroupBox.TabStop = false;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(6, 22);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password:";
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
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(63, 19);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(191, 20);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBoxTextChanged);
            // 
            // PasswordCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 125);
            this.Controls.Add(copyrightLabel);
            this.Controls.Add(passwordGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PasswordCheckForm";
            this.Text = "Battleships: Lock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PasswordCheckFormClosing);
            passwordGroupBox.ResumeLayout(false);
            passwordGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox passwordTextBox;
    }
}
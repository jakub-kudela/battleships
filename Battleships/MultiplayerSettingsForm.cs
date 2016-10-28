using System;
using System.Windows.Forms;

namespace Battleships
{
    public partial class MultiplayerSettingsForm : Form
    {
        public MultiplayerSettingsForm()
        {
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set location of the form to the top left corner of the parent.
            CenterToParent();
            // Set the title text for better player orientation.
            if (Game.playerSwitch)
            {
                Text = "Battleships: Player 1's settings";
            }
            else
            {
                Text = "Battleships: Player 2's settings";
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            // Check the length of the name.
            if (nameTextBox.Text.Length >= 3 && nameTextBox.Text.Length <= 12 && passwordTextBox.Text.Length >= 3 
                && passwordTextBox.Text.Length <= 12)
            {
                // Set player's name and password.
                if (Game.playerSwitch)
                {
                    Game.player1.Name = nameTextBox.Text;
                    Game.player1.Password = passwordTextBox.Text;
                }
                else
                {
                    Game.player2.Name = nameTextBox.Text;
                    Game.player2.Password = passwordTextBox.Text;
                }

                ShipDeploymentForm shipDeploymentForm = new ShipDeploymentForm();
                shipDeploymentForm.Location = Location;
                shipDeploymentForm.Show();

                // Dispose does not trigger FormClosing event.
                Dispose();
            }
            else
            {
                // Show a warning message box.
                MessageBox.Show("Your name and password must be from 3 to 12 characters long, try again please.", "Battleships: Try another name or password!");
                nameTextBox.Text = "";
            }
        }

        private void PasswordTextBoxTextChanged(object sender, EventArgs e)
        {
            // Anonymize the password string.
            passwordTextBox.PasswordChar = '●';
        }

        // Only with a focus on the button continue when enter pressed.
        private void MultiplayerSettingsFormEnter(object sender, EventArgs e)
        {
            OkButtonClick(sender, e);
        }

        private void MultiplayerSettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult quitToMainMenu = MessageBox.Show("Do you really want to quit game to Main menu?", "Battleships: Quitting game...", MessageBoxButtons.YesNo);
            if (quitToMainMenu == DialogResult.Yes)
            {
                // In case someone presses close button, show the dialog box.
                GlobalContext.MainMenuForm.Location = Location;
                GlobalContext.MainMenuForm.Show();
            }
            else
            {
                // Prevent form from closing.
                e.Cancel = true;
            }
        }
    }
}

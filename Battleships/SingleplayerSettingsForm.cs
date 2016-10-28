using System;
using System.Windows.Forms;

namespace Battleships
{
    public partial class SingleplayerSettingsForm : Form
    {
        public SingleplayerSettingsForm()
        {
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set location of the form to the top left corner of the parent.
            CenterToParent();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            // Check the length of the name.
            if (nameTextBox.Text.Length >= 3 && nameTextBox.Text.Length <= 12)
            {
                // Set player's name.
                Game.player1.Name = nameTextBox.Text;
                // Other player's name is assigned automatically.
                Game.player2.Name = "Computer";

                ShipDeploymentForm shipDeploymentForm = new ShipDeploymentForm();
                shipDeploymentForm.Location = Location;
                shipDeploymentForm.Show();

                // Dispose does not trigger FormClosing event.
                Dispose();
            }
            else
            {
                // Show a warning message box.
                MessageBox.Show("Your name must be from 3 to 12 characters long, try again please.", "Battleships: Try another name!");
                nameTextBox.Text = "";
            }
        }

        // Only with a focus on the button continue when enter pressed.
        private void SingleplayerSettingsFormEnter(object sender, EventArgs e)
        {
            OkButtonClick(sender, e);
        }

        private void SingleplayerSettingsFormClosing(object sender, FormClosingEventArgs e)
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

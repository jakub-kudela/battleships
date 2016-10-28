using System;
using System.Windows.Forms;

namespace Battleships
{
    public partial class PasswordCheckForm : Form
    {
        public PasswordCheckForm()
        {
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set location of the form to the top left corner of the parent.
            CenterToParent();
            // Set the title text for better player orientation.
            if (Game.playerSwitch)
            {
                Text = "Battleships: " + Game.player1.Name + "’s lock";
            }
            else
            {
                Text = "Battleships: " + Game.player2.Name + "’s lock";
            }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            // Check if the password matches.
            if ((Game.playerSwitch && Game.player1.Password == passwordTextBox.Text) ||
                (!Game.playerSwitch && Game.player2.Password == passwordTextBox.Text))
            {
                // Continue with the game.
                MainGameForm mainGameForm = new MainGameForm();
                mainGameForm.Location = Location;
                mainGameForm.Show();
                Dispose();
            }
            else
            {
                // Show a warning message box.
                MessageBox.Show("Try again, please.", "Battleships: Wrong password!");
                passwordTextBox.Text = "";
            }
        }


        private void PasswordTextBoxTextChanged(object sender, EventArgs e)
        {
            // Anonymize the password string.
            passwordTextBox.PasswordChar = '●';
        }
        
        private void PasswordCheckFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult quitToMainMenu = MessageBox.Show("Do you really want to quit game to Main menu?", "Battleships: Quitting game...", MessageBoxButtons.YesNo);
            if (quitToMainMenu == DialogResult.Yes)
            {
                // Start to play the main menu sound in loop;
                AudioContext.menuSoundPlayer.PlayLooping();

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

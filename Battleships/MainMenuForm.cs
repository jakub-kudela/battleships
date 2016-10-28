using System;
using System.Windows.Forms;

namespace Battleships
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set location of the form to the top left corner of the parent.
            CenterToScreen();
        }

        private void QuitButtonClick(object sender, EventArgs e)
        {
            // The correct way to shut down the whole application.
            Application.Exit();
        }

        private void SingleplayerButtonClick(object sender, EventArgs e)
        {
            // Set game to a Singleplayer.
            Game.gameMode = true;
            Game.Initialize();

            // Initialize players.
            Game.player1 = new Player();
            Game.player2 = new Player();

            // Temporarily hide MainMenuForm and store its pointer.
            SingleplayerSettingsForm singleplayerSettingsForm = new SingleplayerSettingsForm();
            singleplayerSettingsForm.Location = Location;
            singleplayerSettingsForm.Show();
            Hide();
        }

        private void MultiplayerButtonClick(object sender, EventArgs e)
        {
            // Set game to a multiplayer.
            Game.gameMode = false;
            Game.Initialize();

            // Initialize players.
            Game.player1 = new Player();
            Game.player2 = new Player();

            // Temporarily hide MainMenuForm and store its pointer.
            MultiplayerSettingsForm multiplayerSettingsForm = new MultiplayerSettingsForm();
            multiplayerSettingsForm.Location = Location;
            multiplayerSettingsForm.Show();
            Hide();
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            // Open default web browser with the Wiki link.
            System.Diagnostics.Process.Start(@"http://en.wikipedia.org/wiki/Battleship_%28game%29");
        }

        private void CreditsButtonClick(object sender, EventArgs e)
        {
            // Temporarily hide MainMenuForm and store its pointer.
            CreditsForm creditsForm = new CreditsForm();
            creditsForm.Location = Location;
            creditsForm.Show();
            Hide();
        }

        private void MainMenuFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

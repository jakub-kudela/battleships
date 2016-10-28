using System;
using System.Windows.Forms;

namespace Battleships
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
            // Disable maximalization button on the title bar.
            MaximizeBox = false;
            // Set location of the form to the top left corner of the parent.
            CenterToParent();
            creditsLabel.Text = ("Battleships, v 1.00.\nCreated by Jakub Kúdela, 2010.\n© Jakub Kúdela, 2010.");
        }
        
        private void CreditsButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CreditsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // In case someone presses close button, show the dialog box.
            GlobalContext.MainMenuForm.Location = Location;
            GlobalContext.MainMenuForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FightGameAIDemo
{
    /// <summary>
    /// Main menu user form
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainMenu : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu" /> class.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FightGameForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FightGameForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnFightScreen control.
        /// Opens the AI Fight game form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnFightScreen_Click(object sender, EventArgs e)
        {
            //hide the menu form 
            //and open the fighting form
            this.Hide();
            UserInterfaces.FightGameAIMain f = new UserInterfaces.FightGameAIMain();
            f.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnQuit control.
        /// Closes the application
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //close Application
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FightGameAIDemo.GP;
using FightGameAIDemo.Attacks;
using FightGameAIDemo.Behavior_Tree;
using FightGameAIDemo.Fighter_Classes;
using System.Diagnostics;

namespace FightGameAIDemo.UserInterfaces
{
    /// <summary>
    /// User interface of the main fight screen
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FightGameAIMain : Form
    {
        /// <summary>
        /// interface connecting the game world to the fight game screen
        /// </summary>
        IGameWorld gw;

        /// <summary>
        /// The blocking of opponent
        /// </summary>
        bool blocking;
        /// <summary>
        /// The crouching of opponent
        /// </summary>
        bool crouching;

        //number of generations
        /// <summary>
        /// The generation
        /// </summary>
        int generation;

        /// <summary>
        /// The close distance setting from interface
        /// </summary>
        public bool close;
        /// <summary>
        /// The medium distance setting from interface
        /// </summary>
        public bool medium;
        /// <summary>
        /// The far distance setting from interface
        /// </summary>
        public bool far;

        /// <summary>
        /// Initializes a new instance of the <see cref="FightGameAIMain" /> class.
        /// </summary>
        public FightGameAIMain()
        {
            InitializeComponent();

            gw = new GameWorld();

            lstOutPut.DataSource = gw.ListOfEvents;
        }

        /// <summary>
        /// Handles the Load event of the FightGameAIMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FightGameAIMain_Load(object sender, EventArgs e)
        {
            //initalise default setup on form load
            defaultSetup();

            //deactivate the round settings
            chkRoundWait.Enabled = false;
            nudRounds.Enabled = false;
            rdoAllMsg.Enabled = false;

        }

        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Enables the fighter settings.
        /// </summary>
        /// <param name="set">if set to <c>true</c> [set].</param>
        private void enableFighterSettings(bool set)
        {
            //Enables or disables all controlls in the section
            gpoFighterSettings.Enabled = set;
            btnRun.Enabled = set;
        }
        /// <summary>
        /// Enables the algorithm settings.
        /// </summary>
        /// <param name="set">if set to <c>true</c> [set].</param>
        private void enableAlgSettings(bool set)
        {
            gpoAlgSettings.Enabled = set;
        }
        /// <summary>
        /// Enables the simulation settings.
        /// </summary>
        /// <param name="set">if set to <c>true</c> [set].</param>
        private void enableSimSettings(bool set)
        {
            gpoSimSettings.Enabled = set;
        }
        /// <summary>
        /// setup the user interface with the default settings.
        /// </summary>
        private void defaultSetup()
        {
            //enable all controlls
            enableFighterSettings(true);
            enableAlgSettings(true);
            enableSimSettings(true);

            //set up default settings for form
            rdoFightMsg.Select();
            rdoStanding.Select();
            rdoClose.Select();

        }

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoFightMsg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoFightMsg_CheckedChanged(object sender, EventArgs e)
        {
            lstOutPut.DataSource = gw.ListOfEvents;
            UpdateOutput();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoAlgMsg control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoAlgMsg_CheckedChanged(object sender, EventArgs e)
        {
            lstOutPut.DataSource = gw.ListEventsAlgorithm;
            UpdateOutput();
        }

        /// <summary>
        /// Handles the Click event of the btnRun control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            enableFighterSettings(false);
            enableAlgSettings(false);
            enableSimSettings(false);

            //sets number of ronds which each run an indiviual of the fight game
            //and there for tree
            int NoOfround = (int)nudIndeviduals.Value;

            int Torniment_size = (int)nudTornSize.Value;

            generation = (int)nudGenerations.Value;

            chkRoundWait.Enabled = false;
            nudRounds.Enabled = false;

            //update the content of the output ListBox
            UpdateOutput();

            gw.Crouched = crouching;
            gw.Close = close;
            gw.Population_size = NoOfround;
            //setup game
            gw.SetUp(blocking, crouching, Torniment_size, NoOfround);

            //for dev debug
            //Stopwatch stopwatch = new Stopwatch();

            for (int g = 0; g < generation; g++)
            {
                //stopwatch.Start();
                //handle each round
                for (int i = 0; i != NoOfround; i++)
                {
                    //run the fight
                    gw.RunFight();

                    //update the content of the output ListBox
                    UpdateOutput();
                }
                //stopwatch.Stop();

                //gw.ListOfEvents.Add("Time in Miliseconds for 2 fights:" + stopwatch.Elapsed.Milliseconds.ToString());

                //UpdateOutput();

                if(g != generation-1)
                {
                gw.ListEventsAlgorithm.Add("*                                       *");
                gw.ListOfEvents.Add("*                                       *");
                gw.triggerEvolution();
                }
            }
        }
        //Update method to refreash the Display
        /// <summary>
        /// Updates the output list box with both Algorithm and fighting event lists.
        /// </summary>
        public void UpdateOutput()
        {
            ((CurrencyManager)lstOutPut.BindingContext[gw.ListOfEvents]).Refresh();
            ((CurrencyManager)lstOutPut.BindingContext[gw.ListEventsAlgorithm]).Refresh();
        }

        /// <summary>
        /// Handles the Click event of the btnAbort control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnAbort_Click(object sender, EventArgs e)
        {
            //reactivate all deactivated controlls from the run button
            enableFighterSettings(true);
            enableAlgSettings(true);
            enableSimSettings(true);

            //testing
            //byte[] program1 = { 1, 5, 2, 3, 9, 6, 2, 4, 9, 9 };
            //byte[] close = { 1, 6, 2, 3, 9, 6, 2, 4, 9, 9 };
            //byte[] program2 = { 1, 3, 5, 2, 9, 4, 2, 9 };
            //byte[] program3 = { 1, 8, 8, 5, 2, 9, 5, 6, 6, 4, 4, 4, 9, 9, 6, 5, 8, 3, 3, 3, 9, 8, 3, 9, 9, 5, 6, 6, 4, 9, 9, 9, 5, 3, 9, 9, 9, 5, 4, 9, 9, 9, 8, 8, 2, 2, 9, 9, 3, 9 };
            
            //GeneticProgramming gp = new GeneticProgramming();
            //gp.GetInterpTree(program1);
            //MyTreeBuilder tb = gp.interp_tree_builder;
            //IMyBehaviourTreeNode itb = gp.interp_tree;


            //////gp.GetInterpTree(close);
            ////Indevidual ind3 = new Indevidual();
            ////ind3.Program = close;
            ////gp.Generation[0] = ind3;
            ////gw.Distance = "Close";
            ////gw.SetUp(false, true);
            ////gw.RunFight();


            //Indevidual ind = new Indevidual();
            //Indevidual ind2 = new Indevidual();
            //ind.Program = program1;
            //ind2.Program = program2;

            //gp.setup();

            //gp.evolve();

            //gp.Grow();

            //byte[] prog = gp.GrownProgram;

            //byte[] child = gp.crossover_subtree(ind, ind2);

            ////int r = gp.tree_traverse(ind, 3);

            //byte[] mutant = gp.mutation_bit_flip(program2);
            
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //Exit the application
            Application.Exit();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkBlocking control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void chkBlocking_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlocking.Checked)
            {
                blocking = true;
            }
            else
            {
                blocking = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoClose_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoClose.Checked)
            {
                gw.Distance = "Close";
                medium = false;
                far = false;
                close = true;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoMedium control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoMedium.Checked)
            {
                gw.Distance = "Medium";
                medium = true;
                far = false;
                close = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoFar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoFar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFar.Checked)
            {
                gw.Distance = "Far";
                medium = false;
                far = true;
                close = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoStanding control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoStanding_CheckedChanged(object sender, EventArgs e)
        {
            if(rdoStanding.Checked)
            {
                crouching = false;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoCrouching control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void rdoCrouching_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCrouching.Checked)
            {
                crouching = true;
            }
        }

       
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

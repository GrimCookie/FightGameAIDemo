namespace FightGameAIDemo.UserInterfaces
{
    partial class FightGameAIMain
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters")]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstOutPut = new System.Windows.Forms.ListBox();
            this.gpoFighterSettings = new System.Windows.Forms.GroupBox();
            this.gpoFighterDist = new System.Windows.Forms.GroupBox();
            this.rdoClose = new System.Windows.Forms.RadioButton();
            this.rdoMedium = new System.Windows.Forms.RadioButton();
            this.rdoFar = new System.Windows.Forms.RadioButton();
            this.gpoOpponentPos = new System.Windows.Forms.GroupBox();
            this.rdoStanding = new System.Windows.Forms.RadioButton();
            this.rdoCrouching = new System.Windows.Forms.RadioButton();
            this.chkBlocking = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRoundWait = new System.Windows.Forms.CheckBox();
            this.gpoSimSettings = new System.Windows.Forms.GroupBox();
            this.nudRounds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.gpoDisplay = new System.Windows.Forms.GroupBox();
            this.rdoAllMsg = new System.Windows.Forms.RadioButton();
            this.rdoAlgMsg = new System.Windows.Forms.RadioButton();
            this.rdoFightMsg = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.gpoAlgSettings = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.nudGenerations = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudIndeviduals = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudTornSize = new System.Windows.Forms.NumericUpDown();
            this.gpoFighterSettings.SuspendLayout();
            this.gpoFighterDist.SuspendLayout();
            this.gpoOpponentPos.SuspendLayout();
            this.gpoSimSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounds)).BeginInit();
            this.gpoDisplay.SuspendLayout();
            this.gpoAlgSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndeviduals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTornSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lstOutPut
            // 
            this.lstOutPut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOutPut.FormattingEnabled = true;
            this.lstOutPut.HorizontalScrollbar = true;
            this.lstOutPut.Location = new System.Drawing.Point(3, 12);
            this.lstOutPut.Name = "lstOutPut";
            this.lstOutPut.Size = new System.Drawing.Size(579, 277);
            this.lstOutPut.TabIndex = 0;
            this.lstOutPut.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // gpoFighterSettings
            // 
            this.gpoFighterSettings.Controls.Add(this.gpoFighterDist);
            this.gpoFighterSettings.Controls.Add(this.gpoOpponentPos);
            this.gpoFighterSettings.Controls.Add(this.chkBlocking);
            this.gpoFighterSettings.Location = new System.Drawing.Point(19, 416);
            this.gpoFighterSettings.Name = "gpoFighterSettings";
            this.gpoFighterSettings.Size = new System.Drawing.Size(476, 133);
            this.gpoFighterSettings.TabIndex = 1;
            this.gpoFighterSettings.TabStop = false;
            this.gpoFighterSettings.Text = "Fighter Settings";
            // 
            // gpoFighterDist
            // 
            this.gpoFighterDist.Controls.Add(this.rdoClose);
            this.gpoFighterDist.Controls.Add(this.rdoMedium);
            this.gpoFighterDist.Controls.Add(this.rdoFar);
            this.gpoFighterDist.Location = new System.Drawing.Point(11, 23);
            this.gpoFighterDist.Name = "gpoFighterDist";
            this.gpoFighterDist.Size = new System.Drawing.Size(114, 100);
            this.gpoFighterDist.TabIndex = 9;
            this.gpoFighterDist.TabStop = false;
            this.gpoFighterDist.Text = "Fighter Distance";
            // 
            // rdoClose
            // 
            this.rdoClose.AutoSize = true;
            this.rdoClose.Location = new System.Drawing.Point(21, 19);
            this.rdoClose.Name = "rdoClose";
            this.rdoClose.Size = new System.Drawing.Size(51, 17);
            this.rdoClose.TabIndex = 1;
            this.rdoClose.TabStop = true;
            this.rdoClose.Text = "Close";
            this.toolTip1.SetToolTip(this.rdoClose, "Set Fighter Distance Close (can be thought of as face to face)");
            this.rdoClose.UseVisualStyleBackColor = true;
            this.rdoClose.CheckedChanged += new System.EventHandler(this.rdoClose_CheckedChanged);
            // 
            // rdoMedium
            // 
            this.rdoMedium.AutoSize = true;
            this.rdoMedium.Location = new System.Drawing.Point(21, 41);
            this.rdoMedium.Name = "rdoMedium";
            this.rdoMedium.Size = new System.Drawing.Size(62, 17);
            this.rdoMedium.TabIndex = 2;
            this.rdoMedium.TabStop = true;
            this.rdoMedium.Text = "Medium";
            this.toolTip1.SetToolTip(this.rdoMedium, "Sets Fighter Distance medium (Can be thought of as a little more than arms length" +
        ")");
            this.rdoMedium.UseVisualStyleBackColor = true;
            this.rdoMedium.CheckedChanged += new System.EventHandler(this.rdoMedium_CheckedChanged);
            // 
            // rdoFar
            // 
            this.rdoFar.AutoSize = true;
            this.rdoFar.Location = new System.Drawing.Point(21, 64);
            this.rdoFar.Name = "rdoFar";
            this.rdoFar.Size = new System.Drawing.Size(40, 17);
            this.rdoFar.TabIndex = 3;
            this.rdoFar.TabStop = true;
            this.rdoFar.Text = "Far";
            this.toolTip1.SetToolTip(this.rdoFar, "Sets the fighters distance Far (can be thought of as out of physical reach)");
            this.rdoFar.UseVisualStyleBackColor = true;
            this.rdoFar.CheckedChanged += new System.EventHandler(this.rdoFar_CheckedChanged);
            // 
            // gpoOpponentPos
            // 
            this.gpoOpponentPos.Controls.Add(this.rdoStanding);
            this.gpoOpponentPos.Controls.Add(this.rdoCrouching);
            this.gpoOpponentPos.Location = new System.Drawing.Point(131, 23);
            this.gpoOpponentPos.Name = "gpoOpponentPos";
            this.gpoOpponentPos.Size = new System.Drawing.Size(139, 100);
            this.gpoOpponentPos.TabIndex = 8;
            this.gpoOpponentPos.TabStop = false;
            this.gpoOpponentPos.Text = "Opponent Position:";
            // 
            // rdoStanding
            // 
            this.rdoStanding.AutoSize = true;
            this.rdoStanding.Location = new System.Drawing.Point(6, 19);
            this.rdoStanding.Name = "rdoStanding";
            this.rdoStanding.Size = new System.Drawing.Size(67, 17);
            this.rdoStanding.TabIndex = 5;
            this.rdoStanding.TabStop = true;
            this.rdoStanding.Text = "Standing";
            this.toolTip1.SetToolTip(this.rdoStanding, "Set non-AI opponent as standing");
            this.rdoStanding.UseVisualStyleBackColor = true;
            this.rdoStanding.CheckedChanged += new System.EventHandler(this.rdoStanding_CheckedChanged);
            // 
            // rdoCrouching
            // 
            this.rdoCrouching.AutoSize = true;
            this.rdoCrouching.Location = new System.Drawing.Point(6, 41);
            this.rdoCrouching.Name = "rdoCrouching";
            this.rdoCrouching.Size = new System.Drawing.Size(72, 17);
            this.rdoCrouching.TabIndex = 6;
            this.rdoCrouching.TabStop = true;
            this.rdoCrouching.Text = "crouching";
            this.toolTip1.SetToolTip(this.rdoCrouching, "Set Non-AI opponent to Crouching");
            this.rdoCrouching.UseVisualStyleBackColor = true;
            this.rdoCrouching.CheckedChanged += new System.EventHandler(this.rdoCrouching_CheckedChanged);
            // 
            // chkBlocking
            // 
            this.chkBlocking.AutoSize = true;
            this.chkBlocking.Location = new System.Drawing.Point(287, 30);
            this.chkBlocking.Name = "chkBlocking";
            this.chkBlocking.Size = new System.Drawing.Size(127, 17);
            this.chkBlocking.TabIndex = 7;
            this.chkBlocking.Text = "Opponent is Blocking";
            this.toolTip1.SetToolTip(this.chkBlocking, "Set the opponent to Block all incoming attacks (reducing damage by 50%)");
            this.chkBlocking.UseVisualStyleBackColor = true;
            this.chkBlocking.CheckedChanged += new System.EventHandler(this.chkBlocking_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enable Round Wait: ";
            this.toolTip1.SetToolTip(this.label1, "Set a wait period of 1 second after a round finishes (delays readout)");
            // 
            // chkRoundWait
            // 
            this.chkRoundWait.AutoSize = true;
            this.chkRoundWait.Location = new System.Drawing.Point(119, 29);
            this.chkRoundWait.Name = "chkRoundWait";
            this.chkRoundWait.Size = new System.Drawing.Size(44, 17);
            this.chkRoundWait.TabIndex = 1;
            this.chkRoundWait.Text = "Yes";
            this.chkRoundWait.UseVisualStyleBackColor = true;
            this.chkRoundWait.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // gpoSimSettings
            // 
            this.gpoSimSettings.Controls.Add(this.nudRounds);
            this.gpoSimSettings.Controls.Add(this.label2);
            this.gpoSimSettings.Controls.Add(this.gpoDisplay);
            this.gpoSimSettings.Controls.Add(this.chkRoundWait);
            this.gpoSimSettings.Controls.Add(this.label1);
            this.gpoSimSettings.Location = new System.Drawing.Point(19, 302);
            this.gpoSimSettings.Name = "gpoSimSettings";
            this.gpoSimSettings.Size = new System.Drawing.Size(475, 108);
            this.gpoSimSettings.TabIndex = 2;
            this.gpoSimSettings.TabStop = false;
            this.gpoSimSettings.Text = "Simulation Settings";
            // 
            // nudRounds
            // 
            this.nudRounds.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRounds.Location = new System.Drawing.Point(117, 54);
            this.nudRounds.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRounds.Name = "nudRounds";
            this.nudRounds.Size = new System.Drawing.Size(55, 20);
            this.nudRounds.TabIndex = 7;
            this.toolTip1.SetToolTip(this.nudRounds, "increments in 10\'s");
            this.nudRounds.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number of Rounds: ";
            this.toolTip1.SetToolTip(this.label2, "Sets the number of fights to be run");
            // 
            // gpoDisplay
            // 
            this.gpoDisplay.Controls.Add(this.rdoAllMsg);
            this.gpoDisplay.Controls.Add(this.rdoAlgMsg);
            this.gpoDisplay.Controls.Add(this.rdoFightMsg);
            this.gpoDisplay.Location = new System.Drawing.Point(238, 16);
            this.gpoDisplay.Name = "gpoDisplay";
            this.gpoDisplay.Size = new System.Drawing.Size(200, 86);
            this.gpoDisplay.TabIndex = 5;
            this.gpoDisplay.TabStop = false;
            this.gpoDisplay.Text = "Display";
            // 
            // rdoAllMsg
            // 
            this.rdoAllMsg.AutoSize = true;
            this.rdoAllMsg.Location = new System.Drawing.Point(8, 19);
            this.rdoAllMsg.Name = "rdoAllMsg";
            this.rdoAllMsg.Size = new System.Drawing.Size(108, 17);
            this.rdoAllMsg.TabIndex = 2;
            this.rdoAllMsg.TabStop = true;
            this.rdoAllMsg.Text = "Display All events";
            this.toolTip1.SetToolTip(this.rdoAllMsg, "Display all system events  as they happen");
            this.rdoAllMsg.UseVisualStyleBackColor = true;
            this.rdoAllMsg.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoAlgMsg
            // 
            this.rdoAlgMsg.AutoSize = true;
            this.rdoAlgMsg.Location = new System.Drawing.Point(8, 57);
            this.rdoAlgMsg.Name = "rdoAlgMsg";
            this.rdoAlgMsg.Size = new System.Drawing.Size(162, 17);
            this.rdoAlgMsg.TabIndex = 4;
            this.rdoAlgMsg.TabStop = true;
            this.rdoAlgMsg.Text = "Display only Algorithm events";
            this.toolTip1.SetToolTip(this.rdoAlgMsg, "Display only Algorithm events as they happen");
            this.rdoAlgMsg.UseVisualStyleBackColor = true;
            this.rdoAlgMsg.CheckedChanged += new System.EventHandler(this.rdoAlgMsg_CheckedChanged);
            // 
            // rdoFightMsg
            // 
            this.rdoFightMsg.AutoSize = true;
            this.rdoFightMsg.Location = new System.Drawing.Point(8, 38);
            this.rdoFightMsg.Name = "rdoFightMsg";
            this.rdoFightMsg.Size = new System.Drawing.Size(142, 17);
            this.rdoFightMsg.TabIndex = 3;
            this.rdoFightMsg.TabStop = true;
            this.rdoFightMsg.Text = "Display only Fight events";
            this.toolTip1.SetToolTip(this.rdoFightMsg, "Display only fight game events as they happen");
            this.rdoFightMsg.UseVisualStyleBackColor = true;
            this.rdoFightMsg.CheckedChanged += new System.EventHandler(this.rdoFightMsg_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(15, 555);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 32);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(106, 555);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(85, 32);
            this.btnAbort.TabIndex = 4;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // gpoAlgSettings
            // 
            this.gpoAlgSettings.Controls.Add(this.label5);
            this.gpoAlgSettings.Controls.Add(this.nudTornSize);
            this.gpoAlgSettings.Controls.Add(this.label4);
            this.gpoAlgSettings.Controls.Add(this.nudIndeviduals);
            this.gpoAlgSettings.Controls.Add(this.label3);
            this.gpoAlgSettings.Controls.Add(this.nudGenerations);
            this.gpoAlgSettings.Location = new System.Drawing.Point(588, 7);
            this.gpoAlgSettings.Name = "gpoAlgSettings";
            this.gpoAlgSettings.Size = new System.Drawing.Size(268, 574);
            this.gpoAlgSettings.TabIndex = 5;
            this.gpoAlgSettings.TabStop = false;
            this.gpoAlgSettings.Text = "Algorithm Settings";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(410, 555);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 32);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // nudGenerations
            // 
            this.nudGenerations.Location = new System.Drawing.Point(135, 64);
            this.nudGenerations.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGenerations.Name = "nudGenerations";
            this.nudGenerations.Size = new System.Drawing.Size(55, 20);
            this.nudGenerations.TabIndex = 8;
            this.nudGenerations.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Generation number: ";
            this.toolTip1.SetToolTip(this.label3, "The number of Generations to be run");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Indevidual number: ";
            this.toolTip1.SetToolTip(this.label4, "the number of individuals (population) that make up a generation");
            // 
            // nudIndeviduals
            // 
            this.nudIndeviduals.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudIndeviduals.Location = new System.Drawing.Point(135, 35);
            this.nudIndeviduals.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudIndeviduals.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudIndeviduals.Name = "nudIndeviduals";
            this.nudIndeviduals.Size = new System.Drawing.Size(55, 20);
            this.nudIndeviduals.TabIndex = 10;
            this.nudIndeviduals.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Torniment Size: ";
            this.toolTip1.SetToolTip(this.label5, "Sets the number of indeviduals that the torniment selector opperation compares an" +
        " indevidual with for highest fitness score");
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // nudTornSize
            // 
            this.nudTornSize.Location = new System.Drawing.Point(135, 112);
            this.nudTornSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudTornSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTornSize.Name = "nudTornSize";
            this.nudTornSize.Size = new System.Drawing.Size(55, 20);
            this.nudTornSize.TabIndex = 12;
            this.nudTornSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudTornSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FightGameAIMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 592);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gpoAlgSettings);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.gpoSimSettings);
            this.Controls.Add(this.gpoFighterSettings);
            this.Controls.Add(this.lstOutPut);
            this.Name = "FightGameAIMain";
            this.Text = "FightGameAIMain";
            this.Load += new System.EventHandler(this.FightGameAIMain_Load);
            this.gpoFighterSettings.ResumeLayout(false);
            this.gpoFighterSettings.PerformLayout();
            this.gpoFighterDist.ResumeLayout(false);
            this.gpoFighterDist.PerformLayout();
            this.gpoOpponentPos.ResumeLayout(false);
            this.gpoOpponentPos.PerformLayout();
            this.gpoSimSettings.ResumeLayout(false);
            this.gpoSimSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRounds)).EndInit();
            this.gpoDisplay.ResumeLayout(false);
            this.gpoDisplay.PerformLayout();
            this.gpoAlgSettings.ResumeLayout(false);
            this.gpoAlgSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndeviduals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTornSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstOutPut;
        private System.Windows.Forms.GroupBox gpoFighterSettings;
        private System.Windows.Forms.CheckBox chkRoundWait;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBlocking;
        private System.Windows.Forms.RadioButton rdoCrouching;
        private System.Windows.Forms.RadioButton rdoStanding;
        private System.Windows.Forms.RadioButton rdoFar;
        private System.Windows.Forms.RadioButton rdoMedium;
        private System.Windows.Forms.RadioButton rdoClose;
        private System.Windows.Forms.GroupBox gpoSimSettings;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.GroupBox gpoAlgSettings;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.RadioButton rdoAlgMsg;
        private System.Windows.Forms.RadioButton rdoFightMsg;
        private System.Windows.Forms.RadioButton rdoAllMsg;
        private System.Windows.Forms.GroupBox gpoFighterDist;
        private System.Windows.Forms.GroupBox gpoOpponentPos;
        private System.Windows.Forms.GroupBox gpoDisplay;
        private System.Windows.Forms.NumericUpDown nudRounds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudGenerations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudIndeviduals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudTornSize;
    }
}
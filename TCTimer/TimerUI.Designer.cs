namespace TCTimer
{
    partial class TimerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerForm));
            this.showTimerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.advancedRoundEditor = new System.Windows.Forms.Button();
            this.breakTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.minutesPerRoundUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfRoundsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentRoundLabel = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.previousRoundButton = new System.Windows.Forms.Button();
            this.nextRoundButton = new System.Windows.Forms.Button();
            this.addOneMinute = new System.Windows.Forms.Button();
            this.substractOneMinute = new System.Windows.Forms.Button();
            this.stopStartButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tournamentNameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.shortenUrlCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resultsUrlTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.breakTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.messageDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.showMessageFullscreenCheckBox = new System.Windows.Forms.CheckBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.breakTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.messageDurationUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showTimerButton
            // 
            resources.ApplyResources(this.showTimerButton, "showTimerButton");
            this.showTimerButton.Name = "showTimerButton";
            this.showTimerButton.UseVisualStyleBackColor = true;
            this.showTimerButton.Click += new System.EventHandler(this.showTimerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.advancedRoundEditor);
            this.groupBox1.Controls.Add(this.breakTimeUpDown);
            this.groupBox1.Controls.Add(this.minutesPerRoundUpDown);
            this.groupBox1.Controls.Add(this.numberOfRoundsUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // advancedRoundEditor
            // 
            resources.ApplyResources(this.advancedRoundEditor, "advancedRoundEditor");
            this.advancedRoundEditor.Name = "advancedRoundEditor";
            this.advancedRoundEditor.UseVisualStyleBackColor = true;
            this.advancedRoundEditor.Click += new System.EventHandler(this.advancedRoundEditor_Click);
            // 
            // breakTimeUpDown
            // 
            resources.ApplyResources(this.breakTimeUpDown, "breakTimeUpDown");
            this.breakTimeUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.breakTimeUpDown.Name = "breakTimeUpDown";
            this.breakTimeUpDown.Value = new decimal(new int[] {30, 0, 0, 0});
            this.breakTimeUpDown.ValueChanged += new System.EventHandler(this.breakTimeUpDown_ValueChanged);
            // 
            // minutesPerRoundUpDown
            // 
            this.minutesPerRoundUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.minutesPerRoundUpDown, "minutesPerRoundUpDown");
            this.minutesPerRoundUpDown.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.minutesPerRoundUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.minutesPerRoundUpDown.Name = "minutesPerRoundUpDown";
            this.minutesPerRoundUpDown.Value = new decimal(new int[] {165, 0, 0, 65536});
            this.minutesPerRoundUpDown.ValueChanged += new System.EventHandler(this.minutesPerRoundUpDown_ValueChanged);
            // 
            // numberOfRoundsUpDown
            // 
            resources.ApplyResources(this.numberOfRoundsUpDown, "numberOfRoundsUpDown");
            this.numberOfRoundsUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numberOfRoundsUpDown.Name = "numberOfRoundsUpDown";
            this.numberOfRoundsUpDown.Value = new decimal(new int[] {12, 0, 0, 0});
            this.numberOfRoundsUpDown.ValueChanged += new System.EventHandler(this.numberOfRoundsUpDown_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // currentRoundLabel
            // 
            resources.ApplyResources(this.currentRoundLabel, "currentRoundLabel");
            this.currentRoundLabel.Name = "currentRoundLabel";
            // 
            // currentTime
            // 
            resources.ApplyResources(this.currentTime, "currentTime");
            this.currentTime.Name = "currentTime";
            // 
            // previousRoundButton
            // 
            resources.ApplyResources(this.previousRoundButton, "previousRoundButton");
            this.previousRoundButton.Name = "previousRoundButton";
            this.previousRoundButton.UseVisualStyleBackColor = true;
            this.previousRoundButton.Click += new System.EventHandler(this.previousRoundButton_Click);
            // 
            // nextRoundButton
            // 
            resources.ApplyResources(this.nextRoundButton, "nextRoundButton");
            this.nextRoundButton.Name = "nextRoundButton";
            this.nextRoundButton.UseVisualStyleBackColor = true;
            this.nextRoundButton.Click += new System.EventHandler(this.nextRoundButton_Click);
            // 
            // addOneMinute
            // 
            resources.ApplyResources(this.addOneMinute, "addOneMinute");
            this.addOneMinute.Name = "addOneMinute";
            this.addOneMinute.UseVisualStyleBackColor = true;
            this.addOneMinute.Click += new System.EventHandler(this.addOneMinute_Click);
            // 
            // substractOneMinute
            // 
            resources.ApplyResources(this.substractOneMinute, "substractOneMinute");
            this.substractOneMinute.Name = "substractOneMinute";
            this.substractOneMinute.UseVisualStyleBackColor = true;
            this.substractOneMinute.Click += new System.EventHandler(this.subtractOneMinute_Click);
            // 
            // stopStartButton
            // 
            resources.ApplyResources(this.stopStartButton, "stopStartButton");
            this.stopStartButton.Name = "stopStartButton";
            this.stopStartButton.UseVisualStyleBackColor = true;
            this.stopStartButton.Click += new System.EventHandler(this.stopStartButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tournamentNameTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.shortenUrlCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.resultsUrlTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.breakTextBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tournamentNameTextBox
            // 
            resources.ApplyResources(this.tournamentNameTextBox, "tournamentNameTextBox");
            this.tournamentNameTextBox.Name = "tournamentNameTextBox";
            this.tournamentNameTextBox.TextChanged += new System.EventHandler(this.tournamentNameTextBox_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // shortenUrlCheckBox
            // 
            this.shortenUrlCheckBox.Checked = true;
            this.shortenUrlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.shortenUrlCheckBox, "shortenUrlCheckBox");
            this.shortenUrlCheckBox.Name = "shortenUrlCheckBox";
            this.shortenUrlCheckBox.UseVisualStyleBackColor = true;
            this.shortenUrlCheckBox.CheckStateChanged += new System.EventHandler(this.resultsUrlTextBox_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // resultsUrlTextBox
            // 
            resources.ApplyResources(this.resultsUrlTextBox, "resultsUrlTextBox");
            this.resultsUrlTextBox.Name = "resultsUrlTextBox";
            this.resultsUrlTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.resultsUrlTextBox_KeyPress);
            this.resultsUrlTextBox.LostFocus += new System.EventHandler(this.resultsUrlTextBox_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // breakTextBox
            // 
            resources.ApplyResources(this.breakTextBox, "breakTextBox");
            this.breakTextBox.Name = "breakTextBox";
            this.breakTextBox.TextChanged += new System.EventHandler(this.breakTextBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sendMessageButton);
            this.groupBox3.Controls.Add(this.messageDurationUpDown);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.showMessageFullscreenCheckBox);
            this.groupBox3.Controls.Add(this.messageTextBox);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // sendMessageButton
            // 
            resources.ApplyResources(this.sendMessageButton, "sendMessageButton");
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageDurationUpDown
            // 
            resources.ApplyResources(this.messageDurationUpDown, "messageDurationUpDown");
            this.messageDurationUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.messageDurationUpDown.Minimum = new decimal(new int[] {5, 0, 0, 0});
            this.messageDurationUpDown.Name = "messageDurationUpDown";
            this.messageDurationUpDown.Value = new decimal(new int[] {15, 0, 0, 0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // showMessageFullscreenCheckBox
            // 
            resources.ApplyResources(this.showMessageFullscreenCheckBox, "showMessageFullscreenCheckBox");
            this.showMessageFullscreenCheckBox.Name = "showMessageFullscreenCheckBox";
            this.showMessageFullscreenCheckBox.UseVisualStyleBackColor = true;
            // 
            // messageTextBox
            // 
            this.messageTextBox.AcceptsReturn = true;
            resources.ApplyResources(this.messageTextBox, "messageTextBox");
            this.messageTextBox.Name = "messageTextBox";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.aboutMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // closeMenuItem
            // 
            resources.ApplyResources(this.closeMenuItem, "closeMenuItem");
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.aboutToolStripMenuItem, this.gitHubToolStripMenuItem});
            this.aboutMenuItem.Name = "aboutMenuItem";
            resources.ApplyResources(this.aboutMenuItem, "aboutMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // gitHubToolStripMenuItem
            // 
            resources.ApplyResources(this.gitHubToolStripMenuItem, "gitHubToolStripMenuItem");
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // TimerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stopStartButton);
            this.Controls.Add(this.substractOneMinute);
            this.Controls.Add(this.addOneMinute);
            this.Controls.Add(this.nextRoundButton);
            this.Controls.Add(this.previousRoundButton);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.currentRoundLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showTimerButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TimerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimerForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.breakTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.messageDurationUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button advancedRoundEditor;

        private System.Windows.Forms.Button sendMessageButton;

        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.Button addOneMinute;
        private System.Windows.Forms.TextBox breakTextBox;
        private System.Windows.Forms.NumericUpDown breakTimeUpDown;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.Label currentRoundLabel;
        private System.Windows.Forms.Label currentTime;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.NumericUpDown messageDurationUpDown;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.NumericUpDown minutesPerRoundUpDown;
        private System.Windows.Forms.Button nextRoundButton;
        private System.Windows.Forms.NumericUpDown numberOfRoundsUpDown;
        private System.Windows.Forms.Button previousRoundButton;
        private System.Windows.Forms.TextBox resultsUrlTextBox;
        private System.Windows.Forms.CheckBox shortenUrlCheckBox;
        private System.Windows.Forms.CheckBox showMessageFullscreenCheckBox;
        private System.Windows.Forms.Button showTimerButton;
        private System.Windows.Forms.Button stopStartButton;
        private System.Windows.Forms.Button substractOneMinute;

        #endregion

        private System.Windows.Forms.TextBox tournamentNameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
    }
}
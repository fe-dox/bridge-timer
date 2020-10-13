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
            this.showTimerButton.Image = ((System.Drawing.Image) (resources.GetObject("showTimerButton.Image")));
            this.showTimerButton.Location = new System.Drawing.Point(12, 27);
            this.showTimerButton.Name = "showTimerButton";
            this.showTimerButton.Size = new System.Drawing.Size(134, 54);
            this.showTimerButton.TabIndex = 0;
            this.showTimerButton.Text = "Show Timer";
            this.showTimerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.showTimerButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.showTimerButton.UseVisualStyleBackColor = true;
            this.showTimerButton.Click += new System.EventHandler(this.showTimerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.breakTimeUpDown);
            this.groupBox1.Controls.Add(this.minutesPerRoundUpDown);
            this.groupBox1.Controls.Add(this.numberOfRoundsUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time Settings";
            // 
            // breakTimeUpDown
            // 
            this.breakTimeUpDown.Location = new System.Drawing.Point(130, 66);
            this.breakTimeUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.breakTimeUpDown.Name = "breakTimeUpDown";
            this.breakTimeUpDown.Size = new System.Drawing.Size(54, 20);
            this.breakTimeUpDown.TabIndex = 5;
            this.breakTimeUpDown.Value = new decimal(new int[] {30, 0, 0, 0});
            this.breakTimeUpDown.ValueChanged += new System.EventHandler(this.breakTimeUpDown_ValueChanged);
            // 
            // minutesPerRoundUpDown
            // 
            this.minutesPerRoundUpDown.DecimalPlaces = 1;
            this.minutesPerRoundUpDown.Location = new System.Drawing.Point(130, 40);
            this.minutesPerRoundUpDown.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.minutesPerRoundUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.minutesPerRoundUpDown.Name = "minutesPerRoundUpDown";
            this.minutesPerRoundUpDown.Size = new System.Drawing.Size(54, 20);
            this.minutesPerRoundUpDown.TabIndex = 4;
            this.minutesPerRoundUpDown.Value = new decimal(new int[] {165, 0, 0, 65536});
            this.minutesPerRoundUpDown.ValueChanged += new System.EventHandler(this.minutesPerRoundUpDown_ValueChanged);
            // 
            // numberOfRoundsUpDown
            // 
            this.numberOfRoundsUpDown.Location = new System.Drawing.Point(130, 14);
            this.numberOfRoundsUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numberOfRoundsUpDown.Name = "numberOfRoundsUpDown";
            this.numberOfRoundsUpDown.Size = new System.Drawing.Size(54, 20);
            this.numberOfRoundsUpDown.TabIndex = 3;
            this.numberOfRoundsUpDown.Value = new decimal(new int[] {12, 0, 0, 0});
            this.numberOfRoundsUpDown.ValueChanged += new System.EventHandler(this.numberOfRoundsUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of rounds";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minutes per round";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seconds for break";
            // 
            // currentRoundLabel
            // 
            this.currentRoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.currentRoundLabel.Location = new System.Drawing.Point(479, 58);
            this.currentRoundLabel.Name = "currentRoundLabel";
            this.currentRoundLabel.Size = new System.Drawing.Size(114, 23);
            this.currentRoundLabel.TabIndex = 1;
            this.currentRoundLabel.Text = "Runda 0";
            this.currentRoundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentTime
            // 
            this.currentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.currentTime.Location = new System.Drawing.Point(481, 33);
            this.currentTime.Name = "currentTime";
            this.currentTime.Size = new System.Drawing.Size(112, 25);
            this.currentTime.TabIndex = 0;
            this.currentTime.Text = "00:00";
            this.currentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previousRoundButton
            // 
            this.previousRoundButton.Image = ((System.Drawing.Image) (resources.GetObject("previousRoundButton.Image")));
            this.previousRoundButton.Location = new System.Drawing.Point(237, 27);
            this.previousRoundButton.Name = "previousRoundButton";
            this.previousRoundButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.previousRoundButton.Size = new System.Drawing.Size(54, 54);
            this.previousRoundButton.TabIndex = 4;
            this.previousRoundButton.UseVisualStyleBackColor = true;
            this.previousRoundButton.Click += new System.EventHandler(this.previousRoundButton_Click);
            // 
            // nextRoundButton
            // 
            this.nextRoundButton.Image = ((System.Drawing.Image) (resources.GetObject("nextRoundButton.Image")));
            this.nextRoundButton.Location = new System.Drawing.Point(297, 27);
            this.nextRoundButton.Name = "nextRoundButton";
            this.nextRoundButton.Size = new System.Drawing.Size(54, 54);
            this.nextRoundButton.TabIndex = 5;
            this.nextRoundButton.UseVisualStyleBackColor = true;
            this.nextRoundButton.Click += new System.EventHandler(this.nextRoundButton_Click);
            // 
            // addOneMinute
            // 
            this.addOneMinute.Image = ((System.Drawing.Image) (resources.GetObject("addOneMinute.Image")));
            this.addOneMinute.Location = new System.Drawing.Point(357, 27);
            this.addOneMinute.Name = "addOneMinute";
            this.addOneMinute.Size = new System.Drawing.Size(54, 54);
            this.addOneMinute.TabIndex = 6;
            this.addOneMinute.UseVisualStyleBackColor = true;
            this.addOneMinute.Click += new System.EventHandler(this.addOneMinute_Click);
            // 
            // substractOneMinute
            // 
            this.substractOneMinute.Image = ((System.Drawing.Image) (resources.GetObject("substractOneMinute.Image")));
            this.substractOneMinute.Location = new System.Drawing.Point(417, 27);
            this.substractOneMinute.Name = "substractOneMinute";
            this.substractOneMinute.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.substractOneMinute.Size = new System.Drawing.Size(54, 54);
            this.substractOneMinute.TabIndex = 7;
            this.substractOneMinute.UseVisualStyleBackColor = true;
            this.substractOneMinute.Click += new System.EventHandler(this.subtractOneMinute_Click);
            // 
            // stopStartButton
            // 
            this.stopStartButton.Image = ((System.Drawing.Image) (resources.GetObject("stopStartButton.Image")));
            this.stopStartButton.Location = new System.Drawing.Point(177, 27);
            this.stopStartButton.Name = "stopStartButton";
            this.stopStartButton.Size = new System.Drawing.Size(54, 54);
            this.stopStartButton.TabIndex = 8;
            this.stopStartButton.UseVisualStyleBackColor = true;
            this.stopStartButton.Click += new System.EventHandler(this.stopStartButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shortenUrlCheckBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.resultsUrlTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.breakTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Settings";
            // 
            // shortenUrlCheckBox
            // 
            this.shortenUrlCheckBox.Checked = true;
            this.shortenUrlCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortenUrlCheckBox.Location = new System.Drawing.Point(467, 46);
            this.shortenUrlCheckBox.Name = "shortenUrlCheckBox";
            this.shortenUrlCheckBox.Size = new System.Drawing.Size(98, 18);
            this.shortenUrlCheckBox.TabIndex = 3;
            this.shortenUrlCheckBox.Text = "Shorten URL";
            this.shortenUrlCheckBox.UseVisualStyleBackColor = true;
            this.shortenUrlCheckBox.CheckedChanged += new System.EventHandler(this.shortenUrlCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Results URL";
            // 
            // resultsUrlTextBox
            // 
            this.resultsUrlTextBox.Location = new System.Drawing.Point(91, 45);
            this.resultsUrlTextBox.Name = "resultsUrlTextBox";
            this.resultsUrlTextBox.Size = new System.Drawing.Size(368, 20);
            this.resultsUrlTextBox.TabIndex = 1;
            this.resultsUrlTextBox.TextChanged += new System.EventHandler(this.resultsUrlTextBox_TextChanged);
            this.resultsUrlTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.resultsUrlTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Break text";
            // 
            // breakTextBox
            // 
            this.breakTextBox.Location = new System.Drawing.Point(91, 19);
            this.breakTextBox.MaxLength = 120;
            this.breakTextBox.Name = "breakTextBox";
            this.breakTextBox.Size = new System.Drawing.Size(474, 20);
            this.breakTextBox.TabIndex = 0;
            this.breakTextBox.TextChanged += new System.EventHandler(this.breakTextBox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sendMessageButton);
            this.groupBox3.Controls.Add(this.messageDurationUpDown);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.showMessageFullscreenCheckBox);
            this.groupBox3.Controls.Add(this.messageTextBox);
            this.groupBox3.Location = new System.Drawing.Point(208, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 99);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message";
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Location = new System.Drawing.Point(253, 66);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(126, 23);
            this.sendMessageButton.TabIndex = 5;
            this.sendMessageButton.Text = "Send Message";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.sendMessageButton_Click);
            // 
            // messageDurationUpDown
            // 
            this.messageDurationUpDown.Location = new System.Drawing.Point(317, 40);
            this.messageDurationUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.messageDurationUpDown.Minimum = new decimal(new int[] {5, 0, 0, 0});
            this.messageDurationUpDown.Name = "messageDurationUpDown";
            this.messageDurationUpDown.Size = new System.Drawing.Size(62, 20);
            this.messageDurationUpDown.TabIndex = 4;
            this.messageDurationUpDown.Value = new decimal(new int[] {5, 0, 0, 0});
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(251, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Duration";
            // 
            // showMessageFullscreenCheckBox
            // 
            this.showMessageFullscreenCheckBox.Location = new System.Drawing.Point(253, 19);
            this.showMessageFullscreenCheckBox.Name = "showMessageFullscreenCheckBox";
            this.showMessageFullscreenCheckBox.Size = new System.Drawing.Size(104, 20);
            this.showMessageFullscreenCheckBox.TabIndex = 2;
            this.showMessageFullscreenCheckBox.Text = "Show fullscreen";
            this.showMessageFullscreenCheckBox.UseVisualStyleBackColor = true;
            // 
            // messageTextBox
            // 
            this.messageTextBox.AcceptsReturn = true;
            this.messageTextBox.Location = new System.Drawing.Point(6, 19);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.PasswordChar = '$';
            this.messageTextBox.Size = new System.Drawing.Size(241, 74);
            this.messageTextBox.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.aboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(605, 276);
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
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimerForm";
            this.Text = "Bridge Timer";
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
    }
}
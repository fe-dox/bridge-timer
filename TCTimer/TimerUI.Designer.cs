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
            this.showTimerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.minutesPerRoundUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfRoundsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentRoundLabel = new System.Windows.Forms.Label();
            this.currentTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shortenUrlCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.resultsUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.breakTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // showTimerButton
            // 
            this.showTimerButton.Location = new System.Drawing.Point(12, 27);
            this.showTimerButton.Name = "showTimerButton";
            this.showTimerButton.Size = new System.Drawing.Size(134, 54);
            this.showTimerButton.TabIndex = 0;
            this.showTimerButton.Text = "Show Timer";
            this.showTimerButton.UseVisualStyleBackColor = true;
            this.showTimerButton.Click += new System.EventHandler(this.showTimerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown3);
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
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(130, 66);
            this.numericUpDown3.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown3.TabIndex = 5;
            this.numericUpDown3.Value = new decimal(new int[] {30, 0, 0, 0});
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
            this.minutesPerRoundUpDown.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numberOfRoundsUpDown
            // 
            this.numberOfRoundsUpDown.Location = new System.Drawing.Point(130, 14);
            this.numberOfRoundsUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numberOfRoundsUpDown.Name = "numberOfRoundsUpDown";
            this.numberOfRoundsUpDown.Size = new System.Drawing.Size(54, 20);
            this.numberOfRoundsUpDown.TabIndex = 3;
            this.numberOfRoundsUpDown.Value = new decimal(new int[] {12, 0, 0, 0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of rounds";
            this.label1.Click += new System.EventHandler(this.label1_Click);
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
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time for break";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // currentRoundLabel
            // 
            this.currentRoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.currentRoundLabel.Location = new System.Drawing.Point(479, 58);
            this.currentRoundLabel.Name = "currentRoundLabel";
            this.currentRoundLabel.Size = new System.Drawing.Size(114, 23);
            this.currentRoundLabel.TabIndex = 1;
            this.currentRoundLabel.Text = "Runda 11";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 54);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(297, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 54);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(357, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 54);
            this.button3.TabIndex = 6;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(417, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 54);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(177, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 54);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.shortenUrlCheck);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.resultsUrl);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.breakTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(581, 74);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional Settings";
            // 
            // shortenUrlCheck
            // 
            this.shortenUrlCheck.Checked = true;
            this.shortenUrlCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortenUrlCheck.Location = new System.Drawing.Point(467, 46);
            this.shortenUrlCheck.Name = "shortenUrlCheck";
            this.shortenUrlCheck.Size = new System.Drawing.Size(98, 18);
            this.shortenUrlCheck.TabIndex = 3;
            this.shortenUrlCheck.Text = "Shorten URL";
            this.shortenUrlCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Results URL";
            // 
            // resultsUrl
            // 
            this.resultsUrl.Location = new System.Drawing.Point(91, 45);
            this.resultsUrl.Name = "resultsUrl";
            this.resultsUrl.Size = new System.Drawing.Size(368, 20);
            this.resultsUrl.TabIndex = 1;
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
            this.breakTextBox.Name = "breakTextBox";
            this.breakTextBox.Size = new System.Drawing.Size(474, 20);
            this.breakTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(208, 87);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 99);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Message";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // TimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(605, 276);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentTime);
            this.Controls.Add(this.currentRoundLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showTimerButton);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(15, 15);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TimerForm";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox breakTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.NumericUpDown minutesPerRoundUpDown;
        private System.Windows.Forms.NumericUpDown numberOfRoundsUpDown;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.TextBox resultsUrl;
        private System.Windows.Forms.CheckBox shortenUrlCheck;
        private System.Windows.Forms.Button showTimerButton;

        #endregion
    }
}
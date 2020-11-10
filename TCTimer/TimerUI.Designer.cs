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
            this.label12 = new System.Windows.Forms.Label();
            this.blinkingDurationNumericUpDown = new System.Windows.Forms.NumericUpDown();
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
            this.groupBoxFtp = new System.Windows.Forms.GroupBox();
            this.uploadTimerNowButton = new System.Windows.Forms.Button();
            this.uploadSupportFilesButton = new System.Windows.Forms.Button();
            this.buttonLoadLastCredentials = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.ftpStatusIndicator = new System.Windows.Forms.Button();
            this.checkBoxFtpEnabled = new System.Windows.Forms.CheckBox();
            this.textBoxFtpPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFtpUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxFtpPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.appearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.radioColourfulCSS = new System.Windows.Forms.RadioButton();
            this.chooseCustomCSSButton = new System.Windows.Forms.Button();
            this.customCSSLabel = new System.Windows.Forms.Label();
            this.radioCustomCSS = new System.Windows.Forms.RadioButton();
            this.radioHighContrastCSS = new System.Windows.Forms.RadioButton();
            this.radioWhiteOnBlackCSS = new System.Windows.Forms.RadioButton();
            this.radioBlackOnWhiteCSS = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.enableByDefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.resultsIframeCheckBox = new System.Windows.Forms.CheckBox();
            this.selectRoundsButton = new System.Windows.Forms.Button();
            this.selectedRoundsLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.iframeSourceTextBox = new System.Windows.Forms.TextBox();
            this.resultsIframeVisibilityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.clockVisibilityDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.blinkingDurationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.breakTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.messageDurationUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBoxFtp.SuspendLayout();
            this.appearanceGroupBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.resultsIframeVisibilityUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.clockVisibilityDurationUpDown)).BeginInit();
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
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.blinkingDurationNumericUpDown);
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
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // blinkingDurationNumericUpDown
            // 
            resources.ApplyResources(this.blinkingDurationNumericUpDown, "blinkingDurationNumericUpDown");
            this.blinkingDurationNumericUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.blinkingDurationNumericUpDown.Name = "blinkingDurationNumericUpDown";
            this.blinkingDurationNumericUpDown.Value = new decimal(new int[] {90, 0, 0, 0});
            this.blinkingDurationNumericUpDown.ValueChanged += new System.EventHandler(this.blinkingDurationNumericUpDown_ValueChanged);
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
            this.breakTimeUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.breakTimeUpDown.Name = "breakTimeUpDown";
            this.breakTimeUpDown.Value = new decimal(new int[] {30, 0, 0, 0});
            this.breakTimeUpDown.ValueChanged += new System.EventHandler(this.breakTimeUpDown_ValueChanged);
            // 
            // minutesPerRoundUpDown
            // 
            this.minutesPerRoundUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.minutesPerRoundUpDown, "minutesPerRoundUpDown");
            this.minutesPerRoundUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
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
            this.tournamentNameTextBox.Leave += new System.EventHandler(this.tournamentNameTextBox_TextChanged);
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
            this.shortenUrlCheckBox.CheckedChanged += new System.EventHandler(this.resultsUrlTextBox_TextChanged);
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
            this.breakTextBox.Leave += new System.EventHandler(this.breakTextBox_TextChanged);
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
            this.messageDurationUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
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
            // groupBoxFtp
            // 
            this.groupBoxFtp.Controls.Add(this.uploadTimerNowButton);
            this.groupBoxFtp.Controls.Add(this.uploadSupportFilesButton);
            this.groupBoxFtp.Controls.Add(this.buttonLoadLastCredentials);
            this.groupBoxFtp.Controls.Add(this.label19);
            this.groupBoxFtp.Controls.Add(this.ftpStatusIndicator);
            this.groupBoxFtp.Controls.Add(this.checkBoxFtpEnabled);
            this.groupBoxFtp.Controls.Add(this.textBoxFtpPassword);
            this.groupBoxFtp.Controls.Add(this.label8);
            this.groupBoxFtp.Controls.Add(this.textBoxFtpUsername);
            this.groupBoxFtp.Controls.Add(this.label9);
            this.groupBoxFtp.Controls.Add(this.textBoxFtpPath);
            this.groupBoxFtp.Controls.Add(this.label10);
            resources.ApplyResources(this.groupBoxFtp, "groupBoxFtp");
            this.groupBoxFtp.Name = "groupBoxFtp";
            this.groupBoxFtp.TabStop = false;
            // 
            // uploadTimerNowButton
            // 
            resources.ApplyResources(this.uploadTimerNowButton, "uploadTimerNowButton");
            this.uploadTimerNowButton.Name = "uploadTimerNowButton";
            this.uploadTimerNowButton.UseVisualStyleBackColor = true;
            this.uploadTimerNowButton.Click += new System.EventHandler(this.uploadTimerNowButton_Click);
            // 
            // uploadSupportFilesButton
            // 
            resources.ApplyResources(this.uploadSupportFilesButton, "uploadSupportFilesButton");
            this.uploadSupportFilesButton.Name = "uploadSupportFilesButton";
            this.uploadSupportFilesButton.UseVisualStyleBackColor = true;
            this.uploadSupportFilesButton.Click += new System.EventHandler(this.uploadSupportFilesButton_Click);
            // 
            // buttonLoadLastCredentials
            // 
            resources.ApplyResources(this.buttonLoadLastCredentials, "buttonLoadLastCredentials");
            this.buttonLoadLastCredentials.Name = "buttonLoadLastCredentials";
            this.buttonLoadLastCredentials.UseVisualStyleBackColor = true;
            this.buttonLoadLastCredentials.Click += new System.EventHandler(this.buttonLoadLastCredentials_Click);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // ftpStatusIndicator
            // 
            resources.ApplyResources(this.ftpStatusIndicator, "ftpStatusIndicator");
            this.ftpStatusIndicator.BackColor = System.Drawing.Color.Red;
            this.ftpStatusIndicator.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ftpStatusIndicator.Name = "ftpStatusIndicator";
            this.ftpStatusIndicator.UseVisualStyleBackColor = false;
            // 
            // checkBoxFtpEnabled
            // 
            resources.ApplyResources(this.checkBoxFtpEnabled, "checkBoxFtpEnabled");
            this.checkBoxFtpEnabled.Name = "checkBoxFtpEnabled";
            this.checkBoxFtpEnabled.UseVisualStyleBackColor = true;
            this.checkBoxFtpEnabled.CheckedChanged += new System.EventHandler(this.checkBoxFtpEnabled_CheckedChanged);
            // 
            // textBoxFtpPassword
            // 
            resources.ApplyResources(this.textBoxFtpPassword, "textBoxFtpPassword");
            this.textBoxFtpPassword.Name = "textBoxFtpPassword";
            this.textBoxFtpPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // textBoxFtpUsername
            // 
            resources.ApplyResources(this.textBoxFtpUsername, "textBoxFtpUsername");
            this.textBoxFtpUsername.Name = "textBoxFtpUsername";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // textBoxFtpPath
            // 
            resources.ApplyResources(this.textBoxFtpPath, "textBoxFtpPath");
            this.textBoxFtpPath.Name = "textBoxFtpPath";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // appearanceGroupBox
            // 
            this.appearanceGroupBox.Controls.Add(this.radioColourfulCSS);
            this.appearanceGroupBox.Controls.Add(this.chooseCustomCSSButton);
            this.appearanceGroupBox.Controls.Add(this.customCSSLabel);
            this.appearanceGroupBox.Controls.Add(this.radioCustomCSS);
            this.appearanceGroupBox.Controls.Add(this.radioHighContrastCSS);
            this.appearanceGroupBox.Controls.Add(this.radioWhiteOnBlackCSS);
            this.appearanceGroupBox.Controls.Add(this.radioBlackOnWhiteCSS);
            resources.ApplyResources(this.appearanceGroupBox, "appearanceGroupBox");
            this.appearanceGroupBox.Name = "appearanceGroupBox";
            this.appearanceGroupBox.TabStop = false;
            // 
            // radioColourfulCSS
            // 
            resources.ApplyResources(this.radioColourfulCSS, "radioColourfulCSS");
            this.radioColourfulCSS.Name = "radioColourfulCSS";
            this.radioColourfulCSS.TabStop = true;
            this.radioColourfulCSS.UseVisualStyleBackColor = true;
            this.radioColourfulCSS.CheckedChanged += new System.EventHandler(this.radioColourfulCSS_CheckedChanged);
            // 
            // chooseCustomCSSButton
            // 
            resources.ApplyResources(this.chooseCustomCSSButton, "chooseCustomCSSButton");
            this.chooseCustomCSSButton.Name = "chooseCustomCSSButton";
            this.chooseCustomCSSButton.UseVisualStyleBackColor = true;
            this.chooseCustomCSSButton.Click += new System.EventHandler(this.chooseCustomCSSButton_Click);
            // 
            // customCSSLabel
            // 
            resources.ApplyResources(this.customCSSLabel, "customCSSLabel");
            this.customCSSLabel.Name = "customCSSLabel";
            // 
            // radioCustomCSS
            // 
            resources.ApplyResources(this.radioCustomCSS, "radioCustomCSS");
            this.radioCustomCSS.Name = "radioCustomCSS";
            this.radioCustomCSS.TabStop = true;
            this.radioCustomCSS.UseVisualStyleBackColor = true;
            this.radioCustomCSS.CheckedChanged += new System.EventHandler(this.radioCustomCSS_CheckedChanged);
            // 
            // radioHighContrastCSS
            // 
            resources.ApplyResources(this.radioHighContrastCSS, "radioHighContrastCSS");
            this.radioHighContrastCSS.Name = "radioHighContrastCSS";
            this.radioHighContrastCSS.TabStop = true;
            this.radioHighContrastCSS.UseVisualStyleBackColor = true;
            this.radioHighContrastCSS.CheckedChanged += new System.EventHandler(this.radioHighContrastCSS_CheckedChanged);
            // 
            // radioWhiteOnBlackCSS
            // 
            resources.ApplyResources(this.radioWhiteOnBlackCSS, "radioWhiteOnBlackCSS");
            this.radioWhiteOnBlackCSS.Name = "radioWhiteOnBlackCSS";
            this.radioWhiteOnBlackCSS.TabStop = true;
            this.radioWhiteOnBlackCSS.UseVisualStyleBackColor = true;
            this.radioWhiteOnBlackCSS.CheckedChanged += new System.EventHandler(this.radioWhiteOnBlackCSS_CheckedChanged);
            // 
            // radioBlackOnWhiteCSS
            // 
            resources.ApplyResources(this.radioBlackOnWhiteCSS, "radioBlackOnWhiteCSS");
            this.radioBlackOnWhiteCSS.Checked = true;
            this.radioBlackOnWhiteCSS.Name = "radioBlackOnWhiteCSS";
            this.radioBlackOnWhiteCSS.TabStop = true;
            this.radioBlackOnWhiteCSS.UseVisualStyleBackColor = true;
            this.radioBlackOnWhiteCSS.CheckedChanged += new System.EventHandler(this.radioBlackOnWhiteCSS_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.enableByDefaultCheckBox);
            this.groupBox4.Controls.Add(this.resultsIframeCheckBox);
            this.groupBox4.Controls.Add(this.selectRoundsButton);
            this.groupBox4.Controls.Add(this.selectedRoundsLabel);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.iframeSourceTextBox);
            this.groupBox4.Controls.Add(this.resultsIframeVisibilityUpDown);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.clockVisibilityDurationUpDown);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // enableByDefaultCheckBox
            // 
            resources.ApplyResources(this.enableByDefaultCheckBox, "enableByDefaultCheckBox");
            this.enableByDefaultCheckBox.Name = "enableByDefaultCheckBox";
            this.enableByDefaultCheckBox.UseVisualStyleBackColor = true;
            this.enableByDefaultCheckBox.CheckedChanged += new System.EventHandler(this.enableByDefaultCheckBox_CheckedChanged);
            // 
            // resultsIframeCheckBox
            // 
            resources.ApplyResources(this.resultsIframeCheckBox, "resultsIframeCheckBox");
            this.resultsIframeCheckBox.Name = "resultsIframeCheckBox";
            this.resultsIframeCheckBox.UseVisualStyleBackColor = true;
            this.resultsIframeCheckBox.CheckedChanged += new System.EventHandler(this.resultsIframeCheckBox_CheckedChanged);
            // 
            // selectRoundsButton
            // 
            resources.ApplyResources(this.selectRoundsButton, "selectRoundsButton");
            this.selectRoundsButton.Name = "selectRoundsButton";
            this.selectRoundsButton.UseVisualStyleBackColor = true;
            this.selectRoundsButton.Click += new System.EventHandler(this.selectRoundsButton_Click);
            // 
            // selectedRoundsLabel
            // 
            resources.ApplyResources(this.selectedRoundsLabel, "selectedRoundsLabel");
            this.selectedRoundsLabel.Name = "selectedRoundsLabel";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // iframeSourceTextBox
            // 
            resources.ApplyResources(this.iframeSourceTextBox, "iframeSourceTextBox");
            this.iframeSourceTextBox.Name = "iframeSourceTextBox";
            this.iframeSourceTextBox.TextChanged += new System.EventHandler(this.iframeSourceTextBox_TextChanged);
            // 
            // resultsIframeVisibilityUpDown
            // 
            resources.ApplyResources(this.resultsIframeVisibilityUpDown, "resultsIframeVisibilityUpDown");
            this.resultsIframeVisibilityUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.resultsIframeVisibilityUpDown.Name = "resultsIframeVisibilityUpDown";
            this.resultsIframeVisibilityUpDown.Value = new decimal(new int[] {60, 0, 0, 0});
            this.resultsIframeVisibilityUpDown.ValueChanged += new System.EventHandler(this.resultsIframeVisibilityUpDown_ValueChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // clockVisibilityDurationUpDown
            // 
            resources.ApplyResources(this.clockVisibilityDurationUpDown, "clockVisibilityDurationUpDown");
            this.clockVisibilityDurationUpDown.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.clockVisibilityDurationUpDown.Name = "clockVisibilityDurationUpDown";
            this.clockVisibilityDurationUpDown.Value = new decimal(new int[] {60, 0, 0, 0});
            this.clockVisibilityDurationUpDown.ValueChanged += new System.EventHandler(this.clockVisibilityDurationUpDown_ValueChanged);
            // 
            // TimerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.appearanceGroupBox);
            this.Controls.Add(this.groupBoxFtp);
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
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.blinkingDurationNumericUpDown)).EndInit();
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
            this.groupBoxFtp.ResumeLayout(false);
            this.groupBoxFtp.PerformLayout();
            this.appearanceGroupBox.ResumeLayout(false);
            this.appearanceGroupBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.resultsIframeVisibilityUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.clockVisibilityDurationUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown clockVisibilityDurationUpDown;

        private System.Windows.Forms.CheckBox enableByDefaultCheckBox;
        private System.Windows.Forms.TextBox iframeSourceTextBox;
        private System.Windows.Forms.NumericUpDown resultsIframeVisibilityUpDown;
        private System.Windows.Forms.Label selectedRoundsLabel;
        private System.Windows.Forms.Button selectRoundsButton;

        private System.Windows.Forms.CheckBox resultsIframeCheckBox;

        private System.Windows.Forms.Label label14;

        private System.Windows.Forms.Label label13;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.Label customCSSLabel;

        private System.Windows.Forms.Button buttonLoadLastCredentials;

        private System.Windows.Forms.Button chooseCustomCSSButton;

        private System.Windows.Forms.RadioButton radioColourfulCSS;

        private System.Windows.Forms.Button uploadSupportFilesButton;
        private System.Windows.Forms.Button uploadTimerNowButton;

        private System.Windows.Forms.NumericUpDown blinkingDurationNumericUpDown;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.RadioButton radioCustomCSS;

        private System.Windows.Forms.RadioButton radioHighContrastCSS;

        private System.Windows.Forms.RadioButton radioBlackOnWhiteCSS;
        private System.Windows.Forms.RadioButton radioWhiteOnBlackCSS;

        private System.Windows.Forms.GroupBox appearanceGroupBox;

        private System.Windows.Forms.CheckBox checkBoxFtpEnabled;
        private System.Windows.Forms.Button ftpStatusIndicator;
        private System.Windows.Forms.GroupBox groupBoxFtp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxFtpPassword;
        private System.Windows.Forms.TextBox textBoxFtpPath;
        private System.Windows.Forms.TextBox textBoxFtpUsername;

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
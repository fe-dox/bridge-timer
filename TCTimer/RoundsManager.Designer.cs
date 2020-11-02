using System.ComponentModel;
using System.Windows.Forms;

namespace TCTimer
{
    partial class RoundsManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoundsManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timerNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.breakTextTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.roundOvertimeCheckBox = new System.Windows.Forms.CheckBox();
            this.blinkingDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.breakDurationUpDown = new System.Windows.Forms.NumericUpDown();
            this.minutesPerRoundUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfRoundsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.roundsDataGridView = new System.Windows.Forms.DataGridView();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlinkingDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overtime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BreakDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrakText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.blinkingDurationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.breakDurationUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.roundsDataGridView)).BeginInit();
            this.roundContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.timerNameTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.breakTextTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.roundOvertimeCheckBox);
            this.groupBox1.Controls.Add(this.blinkingDurationUpDown);
            this.groupBox1.Controls.Add(this.breakDurationUpDown);
            this.groupBox1.Controls.Add(this.minutesPerRoundUpDown);
            this.groupBox1.Controls.Add(this.numberOfRoundsUpDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // timerNameTextBox
            // 
            resources.ApplyResources(this.timerNameTextBox, "timerNameTextBox");
            this.timerNameTextBox.Name = "timerNameTextBox";
            this.timerNameTextBox.TextChanged += new System.EventHandler(this.timerNameTextBox_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // breakTextTextBox
            // 
            resources.ApplyResources(this.breakTextTextBox, "breakTextTextBox");
            this.breakTextTextBox.Name = "breakTextTextBox";
            this.breakTextTextBox.TextChanged += new System.EventHandler(this.breakTextTextBox_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // roundOvertimeCheckBox
            // 
            resources.ApplyResources(this.roundOvertimeCheckBox, "roundOvertimeCheckBox");
            this.roundOvertimeCheckBox.Name = "roundOvertimeCheckBox";
            this.roundOvertimeCheckBox.UseVisualStyleBackColor = true;
            this.roundOvertimeCheckBox.CheckedChanged += new System.EventHandler(this.roundOvertimeCheckBox_CheckedChanged);
            // 
            // blinkingDurationUpDown
            // 
            resources.ApplyResources(this.blinkingDurationUpDown, "blinkingDurationUpDown");
            this.blinkingDurationUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.blinkingDurationUpDown.Name = "blinkingDurationUpDown";
            this.blinkingDurationUpDown.Value = new decimal(new int[] {90, 0, 0, 0});
            this.blinkingDurationUpDown.ValueChanged += new System.EventHandler(this.blinkingDurationUpDown_ValueChanged);
            // 
            // breakDurationUpDown
            // 
            resources.ApplyResources(this.breakDurationUpDown, "breakDurationUpDown");
            this.breakDurationUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.breakDurationUpDown.Name = "breakDurationUpDown";
            this.breakDurationUpDown.Value = new decimal(new int[] {30, 0, 0, 0});
            this.breakDurationUpDown.ValueChanged += new System.EventHandler(this.breakDurationUpDown_ValueChanged);
            // 
            // minutesPerRoundUpDown
            // 
            this.minutesPerRoundUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.minutesPerRoundUpDown, "minutesPerRoundUpDown");
            this.minutesPerRoundUpDown.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.minutesPerRoundUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.minutesPerRoundUpDown.Name = "minutesPerRoundUpDown";
            this.minutesPerRoundUpDown.Value = new decimal(new int[] {165, 0, 0, 65536});
            this.minutesPerRoundUpDown.ValueChanged += new System.EventHandler(this.minutesPerRoundUpDown_ValueChanged_1);
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
            // roundsDataGridView
            // 
            this.roundsDataGridView.AllowUserToAddRows = false;
            this.roundsDataGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.roundsDataGridView, "roundsDataGridView");
            this.roundsDataGridView.CausesValidation = false;
            this.roundsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roundsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Duration, this.BlinkingDuration, this.Overtime, this.BreakDuration, this.BrakText, this.TimerName});
            this.roundsDataGridView.Name = "roundsDataGridView";
            this.roundsDataGridView.RowTemplate.ContextMenuStrip = this.roundContextMenuStrip;
            this.roundsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.roundsDataGridView_CellValidating);
            this.roundsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.roundsDataGridView_MouseDown);
            // 
            // Duration
            // 
            resources.ApplyResources(this.Duration, "Duration");
            this.Duration.Name = "Duration";
            // 
            // BlinkingDuration
            // 
            resources.ApplyResources(this.BlinkingDuration, "BlinkingDuration");
            this.BlinkingDuration.Name = "BlinkingDuration";
            // 
            // Overtime
            // 
            resources.ApplyResources(this.Overtime, "Overtime");
            this.Overtime.Name = "Overtime";
            // 
            // BreakDuration
            // 
            resources.ApplyResources(this.BreakDuration, "BreakDuration");
            this.BreakDuration.Name = "BreakDuration";
            // 
            // BrakText
            // 
            resources.ApplyResources(this.BrakText, "BrakText");
            this.BrakText.Name = "BrakText";
            // 
            // TimerName
            // 
            resources.ApplyResources(this.TimerName, "TimerName");
            this.TimerName.Name = "TimerName";
            // 
            // roundContextMenuStrip
            // 
            this.roundContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.deleteToolStripMenuItem, this.setToDefaultToolStripMenuItem, this.addRoundToolStripMenuItem});
            this.roundContextMenuStrip.Name = "roundContextMenuStrip";
            resources.ApplyResources(this.roundContextMenuStrip, "roundContextMenuStrip");
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // setToDefaultToolStripMenuItem
            // 
            resources.ApplyResources(this.setToDefaultToolStripMenuItem, "setToDefaultToolStripMenuItem");
            this.setToDefaultToolStripMenuItem.Name = "setToDefaultToolStripMenuItem";
            this.setToDefaultToolStripMenuItem.Click += new System.EventHandler(this.setToDefaultToolStripMenuItem_Click);
            // 
            // addRoundToolStripMenuItem
            // 
            resources.ApplyResources(this.addRoundToolStripMenuItem, "addRoundToolStripMenuItem");
            this.addRoundToolStripMenuItem.Name = "addRoundToolStripMenuItem";
            this.addRoundToolStripMenuItem.Click += new System.EventHandler(this.addRoundToolStripMenuItem_Click);
            // 
            // RoundsManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.roundsDataGridView);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "RoundsManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.blinkingDurationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.breakDurationUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.roundsDataGridView)).EndInit();
            this.roundContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripMenuItem addRoundToolStripMenuItem;

        private System.Windows.Forms.TextBox breakTextTextBox;

        private System.Windows.Forms.NumericUpDown blinkingDurationUpDown;

        private System.Windows.Forms.NumericUpDown breakDurationUpDown;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox timerNameTextBox;

        private System.Windows.Forms.DataGridViewTextBoxColumn TimerName;

        private System.Windows.Forms.DataGridView roundsDataGridView;

        private System.Windows.Forms.ContextMenuStrip roundContextMenuStrip;

        private System.Windows.Forms.ToolStripMenuItem setToDefaultToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.DataGridViewTextBoxColumn BlinkingDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrakText;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Overtime;

        private System.Windows.Forms.CheckBox roundOvertimeCheckBox;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minutesPerRoundUpDown;
        private System.Windows.Forms.NumericUpDown numberOfRoundsUpDown;

        #endregion

        private System.Windows.Forms.Label label5;
    }
}
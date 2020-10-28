using System.ComponentModel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoundsManager));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.everythingOvertime = new System.Windows.Forms.CheckBox();
            this.roundOvertime = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.breakTimeUpDown = new System.Windows.Forms.NumericUpDown();
            this.minutesPerRoundUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfRoundsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BlinkingDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Overtime = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BreakDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrakText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.breakTimeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.everythingOvertime);
            this.groupBox1.Controls.Add(this.roundOvertime);
            this.groupBox1.Controls.Add(this.numericUpDown1);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // everythingOvertime
            // 
            resources.ApplyResources(this.everythingOvertime, "everythingOvertime");
            this.everythingOvertime.Name = "everythingOvertime";
            this.everythingOvertime.UseVisualStyleBackColor = true;
            // 
            // roundOvertime
            // 
            resources.ApplyResources(this.roundOvertime, "roundOvertime");
            this.roundOvertime.Name = "roundOvertime";
            this.roundOvertime.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {30, 0, 0, 0});
            // 
            // breakTimeUpDown
            // 
            resources.ApplyResources(this.breakTimeUpDown, "breakTimeUpDown");
            this.breakTimeUpDown.Maximum = new decimal(new int[] {300, 0, 0, 0});
            this.breakTimeUpDown.Name = "breakTimeUpDown";
            this.breakTimeUpDown.Value = new decimal(new int[] {30, 0, 0, 0});
            // 
            // minutesPerRoundUpDown
            // 
            this.minutesPerRoundUpDown.DecimalPlaces = 1;
            resources.ApplyResources(this.minutesPerRoundUpDown, "minutesPerRoundUpDown");
            this.minutesPerRoundUpDown.Maximum = new decimal(new int[] {120, 0, 0, 0});
            this.minutesPerRoundUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.minutesPerRoundUpDown.Name = "minutesPerRoundUpDown";
            this.minutesPerRoundUpDown.Value = new decimal(new int[] {165, 0, 0, 65536});
            // 
            // numberOfRoundsUpDown
            // 
            resources.ApplyResources(this.numberOfRoundsUpDown, "numberOfRoundsUpDown");
            this.numberOfRoundsUpDown.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numberOfRoundsUpDown.Name = "numberOfRoundsUpDown";
            this.numberOfRoundsUpDown.Value = new decimal(new int[] {12, 0, 0, 0});
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.Duration, this.BlinkingDuration, this.Overtime, this.BreakDuration, this.BrakText});
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
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
            // RoundsManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "RoundsManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.breakTimeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.minutesPerRoundUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numberOfRoundsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn BlinkingDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrakText;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreakDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Overtime;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.CheckBox everythingOvertime;
        private System.Windows.Forms.CheckBox roundOvertime;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.NumericUpDown numericUpDown1;

        private System.Windows.Forms.NumericUpDown breakTimeUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minutesPerRoundUpDown;
        private System.Windows.Forms.NumericUpDown numberOfRoundsUpDown;

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}
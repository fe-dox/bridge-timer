﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace TCTimer
{
    public partial class AboutForm : Form
    {
        private int _numberOfClicks;

        public AboutForm()
        {
            InitializeComponent();
            tournamentVerion.Text = "Version:  " +
                                    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
                                        .FileVersion;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            _numberOfClicks++;
            if (_numberOfClicks == 7)
                MessageBox.Show(
                    "Klikajcie a będzie wam dane",
                    "Amen", MessageBoxButtons.OK);
        }
    }
}
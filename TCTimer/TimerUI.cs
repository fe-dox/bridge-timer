using System;
using System.Windows.Forms;

namespace TCTimer
{
    public partial class TimerForm : Form
    {
        public TimerForm()
        {
            InitializeComponent();
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.Show();
        }
    }
}
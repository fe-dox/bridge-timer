using System;
using System.Windows.Forms;

namespace TCTimer
{
    public partial class AboutForm : Form
    {
        private int _numberOfClicks;

        public AboutForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            _numberOfClicks++;
            if (_numberOfClicks == 7)
                MessageBox.Show(
                    "Ale sobie kliknąłeś, no fajnie tak nie? Jakiś easter egg taki, co? Nie spodziwałeś się tego wcale",
                    "Halo kartus", MessageBoxButtons.OK);
        }
    }
}
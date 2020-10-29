using System;
using System.Windows.Forms;
using Utils;

namespace TCTimer
{
    public partial class RoundsManager : Form
    {
        private readonly TournamentTimer _tournamentTimer;

        public RoundsManager(TournamentTimer timer)
        {
            _tournamentTimer = timer;
            InitializeComponent();
            numberOfRoundsUpDown.Value = _tournamentTimer.NumberOfRounds;
            minutesPerRoundUpDown.Value = _tournamentTimer.DefaultRoundDuration;
            breakDurationUpDown.Value = _tournamentTimer.DefaultBreakDuration;
            blinkingDurationUpDown.Value = _tournamentTimer.DefaultBlinkingDuration;
            roundOvertimeCheckBox.Checked = _tournamentTimer.DefaultOvertimeAfterRound;
            timerNameTextBox.Text = _tournamentTimer.DefaultTimerName;
            breakTextTextBox.Text = _tournamentTimer.DefaultBreakText;
            foreach (var round in _tournamentTimer.RoundsList)
            {
                roundsDataGridView.Rows.Add(round);
            }
        }

        private void setToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void setValueToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
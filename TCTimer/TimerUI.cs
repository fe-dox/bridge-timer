using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace TCTimer
{
    public partial class TimerForm : Form
    {
        private readonly ComponentResourceManager _resources;
        private readonly ResultsUrlShortener _resultsUrlShortener;
        private readonly TournamentTimer _tournamentTimer;


        public TimerForm()
        {
            _resultsUrlShortener = new ResultsUrlShortener();
            _resources = new ComponentResourceManager(typeof(TimerForm));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            FormClosing += TimerForm_FormClosing;
            InitializeComponent();
            _tournamentTimer = new TournamentTimer((int) numberOfRoundsUpDown.Value,
                (float) minutesPerRoundUpDown.Value, (int) breakTimeUpDown.Value);
            _tournamentTimer.Tick += UpdateTime;
            _tournamentTimer.SettingsChanged += UpdateTime;
        }

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs formClosingEvent)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Are you sure?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) formClosingEvent.Cancel = true;
        }

        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog(this);
        }

        private void UpdateTime(object obj, DateTime target)
        {
            currentTime.Text = target.Subtract(DateTime.Now).ToString(@"hh\:mm\:ss");
            currentRoundLabel.Text =
                _tournamentTimer.IsBreak ? "Break" : $@"Round {_tournamentTimer.CurrentRound.ToString()}";
        }

        private void numberOfRoundsUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.NumberOfRounds = (int) numberOfRoundsUpDown.Value;
        }

        private void minutesPerRoundUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.MinutesForRound = (float) minutesPerRoundUpDown.Value;
        }

        private void breakTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.SecondsForBreak = (int) breakTimeUpDown.Value;
        }

        private void breakTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.BreakText = breakTextBox.Text;
        }

        private async void resultsUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!shortenUrlCheckBox.Checked) return;
            if (!Uri.IsWellFormedUriString(resultsUrlTextBox.Text, UriKind.Absolute)) return;
            try
            {
                var shortenedUrl = await
                    Task.Factory.StartNew(() => _resultsUrlShortener.ShortenUrl(new Uri(resultsUrlTextBox.Text)));
                _tournamentTimer.ResultsUrl = shortenedUrl.ToString();
            }
            catch
            {
                MessageBox.Show("Couldn't shorten URL", "Something went wrong", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void showTimerButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void stopStartButton_Click(object sender, EventArgs e)
        {
            if (_tournamentTimer.Running)
            {
                _tournamentTimer.Pause();
                stopStartButton.Image = (Image) _resources.GetObject("stopStartButton.Image");
            }
            else
            {
                _tournamentTimer.Start();
                stopStartButton.Image = (Image) _resources.GetObject("stopButtonImage");
            }
        }

        private void resultsUrlTextBox_KeyPress(object sender, KeyEventArgs e)
        {
            resultsUrlTextBox.BackColor = !Uri.IsWellFormedUriString(resultsUrlTextBox.Text, UriKind.Absolute) &&
                                          !string.IsNullOrEmpty(resultsUrlTextBox.Text)
                ? Color.Coral
                : Color.White;
        }

        private void addOneMinute_Click(object sender, EventArgs e)
        {
            _tournamentTimer.AddMinute();
        }

        private void subtractOneMinute_Click(object sender, EventArgs e)
        {
            _tournamentTimer.SubtractMinute();
        }

        private void nextRoundButton_Click(object sender, EventArgs e)
        {
            _tournamentTimer.NextRound();
        }

        private void previousRoundButton_Click(object sender, EventArgs e)
        {
            _tournamentTimer.PreviousRound();
        }
    }
}
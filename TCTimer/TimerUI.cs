﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using TCTimer.Properties;
using Utils;
using Timer = System.Timers.Timer;

namespace TCTimer
{
    public partial class TimerForm : Form
    {
        private readonly ResultsUrlShortener _resultsUrlShortener;
        private readonly Timer _serializationTimer = new Timer(200);
        private readonly SimpleHttpServer _simpleHttpServer;
        private readonly string _timerPath = Path.GetTempPath() + "\\bridge_timer\\" + Path.GetRandomFileName();
        private readonly TournamentTimer _tournamentTimer;

        public TimerForm()
        {
            _resultsUrlShortener = new ResultsUrlShortener();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            FormClosing += TimerForm_FormClosing;
            InitializeComponent();
            _tournamentTimer = new TournamentTimer((int) numberOfRoundsUpDown.Value,
                (float) minutesPerRoundUpDown.Value, (int) breakTimeUpDown.Value);
            _tournamentTimer.Tick += UpdateTime;
            _tournamentTimer.SettingsChanged += UpdateTime;
            _tournamentTimer.OnFinished += OnFinished;
            _serializationTimer.Elapsed += WriteTournamentTimer;
            _serializationTimer.Start();
            if (!Directory.Exists(_timerPath))
            {
                Directory.CreateDirectory(_timerPath);
            }

            new Task(() =>
            {
                ZipFile.ExtractToDirectory(Application.StartupPath + "\\WebApp.app", _timerPath);
            }).Start();
            _simpleHttpServer = new SimpleHttpServer(_timerPath);
        }

        private void OnFinished(object sender, EventArgs e)
        {
            stopStartButton.Image = Resources.StartWithoutDebug_16x;
        }

        private static void TimerForm_FormClosing(object sender, FormClosingEventArgs formClosingEvent)
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

        private void WriteTournamentTimer(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var serializer = new DataContractSerializer(typeof(TournamentTimer));
            var writer = new FileStream(_timerPath + "\\timer.xml", FileMode.Create);
            serializer.WriteObject(writer, _tournamentTimer);
            writer.Close();
        }

        private void UpdateTime(object obj, DateTime target)
        {
            if (_tournamentTimer.Finished)
            {
                currentTime.Text = DateTime.Now.ToString(@"HH\:mm");
                currentRoundLabel.Text = "Finished";
                return;
            }

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
            if (!Uri.IsWellFormedUriString(resultsUrlTextBox.Text, UriKind.Absolute)) return;
            if (!shortenUrlCheckBox.Checked)
            {
                _tournamentTimer.ResultsUrl = resultsUrlTextBox.Text;
                return;
            }

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
            if (string.IsNullOrEmpty(messageTextBox.Text)) return;
            _tournamentTimer.TimerMessage = new TimerMessage(messageTextBox.Text,
                new TimeSpan(0, 0, (int) messageDurationUpDown.Value),
                DateTime.Now.Add(new TimeSpan(0, 0, 45)), showMessageFullscreenCheckBox.Checked);
            messageTextBox.Text = "";
            messageDurationUpDown.Value = 15;
            showMessageFullscreenCheckBox.Checked = false;
        }

        private void showTimerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"http://localhost:{_simpleHttpServer.Port.ToString()}/");
        }


        private void stopStartButton_Click(object sender, EventArgs e)
        {
            if (_tournamentTimer.Running)
            {
                _tournamentTimer.Pause();
                stopStartButton.Image = Resources.StartWithoutDebug_16x;
            }
            else
            {
                _tournamentTimer.Start();
                stopStartButton.Image = Resources.Pause_16x;
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

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fe-dox/bridge-timer");
        }

        private void tournamentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.TimerName = tournamentNameTextBox.Text;
        }
    }
}
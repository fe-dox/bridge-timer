﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
#if !DEBUG
using System.IO.Compression;
#endif
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCTimer.Properties;
using Utils;
using Utils.Annotations;

namespace TCTimer
{
    public partial class TimerForm : Form
    {
        private readonly ResultsUrlShortener _resultsUrlShortener;
        private readonly SimpleHttpServer _simpleHttpServer;
#if !DEBUG
        private readonly string _timerPath = Path.GetTempPath() + "\\bridge_timer\\" + Path.GetRandomFileName();
#else
        private readonly string _timerPath = "..\\..\\WebApp\\wwwroot";
#endif
        private readonly TournamentTimer _tournamentTimer;
        [CanBeNull] private string _customCss;

        public TimerForm()
        {
            InitializeComponent();
            _resultsUrlShortener = new ResultsUrlShortener();
            _tournamentTimer = new TournamentTimer((int) numberOfRoundsUpDown.Value,
                minutesPerRoundUpDown.Value, (int) breakTimeUpDown.Value, 90);
            _tournamentTimer.Ticked += UpdateTime;
            _tournamentTimer.SettingsChanged += UpdateTime;
            _tournamentTimer.OnFinished += OnFinished;
            _tournamentTimer.FileUpdateRequired += WriteTournamentTimer;
            if (!Directory.Exists(_timerPath))
            {
                Directory.CreateDirectory(_timerPath);
            }
#if !DEBUG
            new Task(() =>
            {
                ZipFile.ExtractToDirectory(Application.StartupPath + "\\WebApp.app", _timerPath);
            }).Start();
#endif
            _simpleHttpServer = new SimpleHttpServer(_timerPath);
            WriteTournamentTimer(this, EventArgs.Empty);
        }

        private void OnFinished(object sender, EventArgs e)
        {
            RunAction(() =>
            {
                stopStartButton.Image = Resources.StartWithoutDebug_16x;
                currentTime.Text = DateTime.Now.ToString(@"HH\:mm");
                currentRoundLabel.Text = "Finished";
            });
        }

        private void TimerForm_FormClosing(object sender, FormClosingEventArgs formClosingEvent)
        {
            if (MessageBox.Show("Are you sure you want to close this window?", "Are you sure?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) formClosingEvent.Cancel = true;
            _simpleHttpServer.Stop();
#if !DEBUG
            try
            {
                Directory.Delete(_timerPath, true);
            }
            catch
            {
                // ignore
            }
#endif
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

        private void WriteTournamentTimer(object sender, EventArgs eventArgs)
        {
            var success = false;
            while (!success)
            {
                var serializer = new DataContractSerializer(typeof(TournamentTimer));
                FileStream writer = null;
                try
                {
                    writer = new FileStream(_timerPath + "\\timer.xml", FileMode.Create);
                    serializer.WriteObject(writer, _tournamentTimer);
                    success = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    success = false;
                }
                finally
                {
                    writer?.Close();
                }
            }
        }

        private void UpdateTime(object obj, DateTime target)
        {
            RunAction(() =>
            {
                currentTime.Text = target >= DateTime.Now
                    ? (target - DateTime.Now).ToString(@"hh\:mm\:ss")
                    : "-" + (target - DateTime.Now).ToString(@"hh\:mm\:ss");
                currentRoundLabel.Text =
                    _tournamentTimer.IsBreak ? "Break" : $@"Round {(_tournamentTimer.CurrentRoundId + 1).ToString()}";
                numberOfRoundsUpDown.Minimum = _tournamentTimer.CurrentRoundId + 1;
            });
        }

        private void RunAction(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void numberOfRoundsUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.NumberOfRounds = (int) numberOfRoundsUpDown.Value;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void minutesPerRoundUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultRoundDuration = minutesPerRoundUpDown.Value;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void breakTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBreakDuration = (int) breakTimeUpDown.Value;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void breakTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBreakText = breakTextBox.Text;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void tournamentNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultTimerName = tournamentNameTextBox.Text;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private async void resultsUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Uri.IsWellFormedUriString(resultsUrlTextBox.Text, UriKind.Absolute)) return;
            if (!shortenUrlCheckBox.Checked)
            {
                _tournamentTimer.ResultsUrl = resultsUrlTextBox.Text.Replace("https://", "").Replace("http://", "");
                _tournamentTimer.OnFileUpdateRequired();
                return;
            }

            try
            {
                var shortenedUrl = await
                    Task.Factory.StartNew(() => _resultsUrlShortener.ShortenUrl(new Uri(resultsUrlTextBox.Text)));
                _tournamentTimer.ResultsUrl = shortenedUrl.ToString().Replace("https://", "");
                _tournamentTimer.OnFileUpdateRequired();
            }
            catch
            {
                MessageBox.Show("Couldn't shorten URL", "Something went wrong", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void sendMessageButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageTextBox.Text)) return;
            _tournamentTimer.TimerMessage = new TimerMessage(messageTextBox.Text,
                new TimeSpan(0, 0, (int) messageDurationUpDown.Value),
                DateTime.Now + new TimeSpan(0, 0, 45), showMessageFullscreenCheckBox.Checked);
        }

        private void showTimerButton_Click(object sender, EventArgs e)
        {
            Process.Start($"http://localhost:{_simpleHttpServer.Port}/");
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
                                          !string.IsNullOrWhiteSpace(resultsUrlTextBox.Text)
                ? Color.LightCoral
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
            _tournamentTimer.GoToNextRound();
        }

        private void previousRoundButton_Click(object sender, EventArgs e)
        {
            _tournamentTimer.GoToPreviousRound();
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/fe-dox/bridge-timer");
        }

        private void advancedRoundEditor_Click(object sender, EventArgs e)
        {
            var roundsManager = new RoundsManager(_tournamentTimer);
            roundsManager.ShowDialog();
            minutesPerRoundUpDown.Value = _tournamentTimer.DefaultRoundDuration;
            breakTimeUpDown.Value = _tournamentTimer.DefaultBreakDuration;
            numberOfRoundsUpDown.Value = _tournamentTimer.NumberOfRounds;
            breakTextBox.Text = _tournamentTimer.DefaultBreakText;
            tournamentNameTextBox.Text = _tournamentTimer.DefaultTimerName;
        }

        private void radioBlackOnWhiteCSS_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioBlackOnWhiteCSS.Checked) return;
            _tournamentTimer.Style = StyleSheet.Default;
        }

        private void radioWhiteOnBlackCSS_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioWhiteOnBlackCSS.Checked) return;
            _tournamentTimer.Style = StyleSheet.WhiteOnBlack;
        }

        private void radioHighContrastCSS_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioHighContrastCSS.Checked) return;
            _tournamentTimer.Style = StyleSheet.HighContrast;
        }

        private void radioColourfulCSS_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioColourfulCSS.Checked) return;
            _tournamentTimer.Style = StyleSheet.Crazy;
        }

        private void radioCustomCSS_CheckedChanged(object sender, EventArgs e)
        {
            chooseCustomCSSButton.Enabled = radioCustomCSS.Checked;
            if (!radioCustomCSS.Checked) return;
            _tournamentTimer.Style = _customCss ?? StyleSheet.Default;
        }

        private void chooseCustomCSSButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Filter = @"css files (*.css)|*.css|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            var filePath = openFileDialog.FileName;
            _customCss = _tournamentTimer.Style = File.ReadAllText(filePath);
            customCSSLabel.Text = Path.GetFileName(filePath);
        }
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCTimer.Properties;
using Utils;
using Utils.Annotations;
using Timer = System.Timers.Timer;

#if !DEBUG
using System.IO.Compression;
#endif

namespace TCTimer
{
    public partial class TimerForm : Form
    {
        private readonly Timer _serializationTimer;
        private readonly ResultsUrlShortener _resultsUrlShortener;
        private readonly SimpleHttpServer _simpleHttpServer;
#if !DEBUG
        private readonly string _timerPath = Path.GetTempPath() + "\\bridge_timer\\" + Path.GetRandomFileName();
#else
        private readonly string _timerPath = "..\\..\\WebApp\\wwwroot";
#endif
        private readonly TournamentTimer _tournamentTimer;
        [CanBeNull] private Ftp _ftp;
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
                // TODO: What if exception here?
                Directory.CreateDirectory(_timerPath);
            }
#if !DEBUG
            new Task(() =>
            {
                ZipFile.ExtractToDirectory(Application.StartupPath + "\\WebApp.app", _timerPath);
            }).Start();
#endif
            // TODO: Constant
            customCSSLabel.Text = Settings.Read("APPEARANCE_FILE_NAME") ?? "None selected";
            // TODO: Constant
            _customCss = Settings.Read("APPEARANCE_CUSTOM_CSS_STRING");
            _simpleHttpServer = new SimpleHttpServer(_timerPath);
            _serializationTimer = new Timer(60_000);
            _serializationTimer.Elapsed += WriteTournamentTimer;
            _serializationTimer.Start();
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
            // TODO: Why is this done independently of whether we closed or not?
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

        private async void WriteTournamentTimer(object sender, EventArgs eventArgs)
        {
            var success = false;
            // TODO: This can never end and hang indefinitely?
            while (!success)
            {
                var serializer = new DataContractSerializer(typeof(TournamentTimer));
                // TODO: [using] instead of this
                FileStream writer = null;
                try
                {
                    writer = new FileStream(_timerPath + "\\timer.xml", FileMode.Create);
                    serializer.WriteObject(writer, _tournamentTimer);
                    success = true;
                }
                catch
                {
                    success = false;
                }
                finally
                {
                    writer?.Close();
                }
            }

            if (_ftp?.Connected ?? false)
            {
                ftpStatusIndicator.BackColor = Color.DodgerBlue;
                await Task.Run(() =>
                {
                    // TODO: What does 2 mean? Why not just success?
                    var success2 = false;
                    // TODO: Again might be infinite loop
                    while (!success2)
                    {
                        if (_ftp == null)
                        {
                            success = true;
                            break;
                        }

                        success2 = _ftp.UploadFile("timer.xml", _timerPath + "\\timer.xml");
                    }
                });
                ftpStatusIndicator.BackColor = Color.LawnGreen;
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
                    _tournamentTimer.IsBreak ? "Break" : $@"Round {_tournamentTimer.CurrentRoundId + 1}";
                numberOfRoundsUpDown.Minimum = _tournamentTimer.CurrentRoundId + 1;
            });
        }

        // TODO: Same function in different place. Move to utils.
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
            UpdateSelectedRoundsLabel();
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

        private void blinkingDurationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBlinkingDuration = (int) blinkingDurationNumericUpDown.Value;
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
                // TODO: Display exception that occurred?
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
            blinkingDurationNumericUpDown.Value = _tournamentTimer.DefaultBlinkingDuration;
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
                Filter = @"css files (*.css)|*.css|All files|*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            var filePath = openFileDialog.FileName;
            _customCss = _tournamentTimer.Style = File.ReadAllText(filePath);
            customCSSLabel.Text = Path.GetFileName(filePath);
            // TODO: Constant
            Settings.Write("APPEARANCE_FILE_NAME", Path.GetFileName(filePath));
            // TODO: Constant
            Settings.Write("APPEARANCE_CUSTOM_CSS_STRING", _customCss);
        }

        private async void checkBoxFtpEnabled_CheckedChanged(object sender, EventArgs e)
        {
            await CheckBoxFtpChanged();
        }

        private async Task CheckBoxFtpChanged()
        {
            textBoxFtpPassword.Enabled = textBoxFtpPath.Enabled = textBoxFtpUsername.Enabled =
                buttonLoadLastCredentials.Enabled = !checkBoxFtpEnabled.Checked;
            ftpStatusIndicator.BackColor = checkBoxFtpEnabled.Checked ? Color.Yellow : Color.Red;

            if (checkBoxFtpEnabled.Checked)
            {
                checkBoxFtpEnabled.Enabled = false;
                await Task.Run(() =>
                {
                    try
                    {
                        _ftp = new Ftp(textBoxFtpUsername.Text, textBoxFtpPassword.Text, textBoxFtpPath.Text);
                        _ftp.ConnectAndCreateDirectories();
                        // TODO: Constants
                        Settings.Write("LAST_FTP_PATH", textBoxFtpPath.Text);
                        Settings.Write("LAST_FTP_USERNAME", textBoxFtpUsername.Text);
                        Settings.Write("LAST_FTP_PASSWORD", textBoxFtpPassword.Text);
                        RunAction(() => ftpStatusIndicator.BackColor = Color.LawnGreen);
                    }
                    catch (Exception exception)
                    {
                        RunAction(() =>
                        {
                            MessageBox.Show($"Can't start FTP {exception.Message}", "Something went wrong",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            checkBoxFtpEnabled.Checked = false;
                        });
                    }
                });
                checkBoxFtpEnabled.Enabled = true;
                uploadSupportFilesButton.Enabled = uploadTimerNowButton.Enabled = checkBoxFtpEnabled.Checked;
            }
            else
            {
                uploadSupportFilesButton.Enabled = uploadTimerNowButton.Enabled = checkBoxFtpEnabled.Checked;
                _ftp = null;
            }
        }

        private void uploadTimerNowButton_Click(object sender, EventArgs e)
        {
            if (!_ftp?.Connected ?? true) return;
            WriteTournamentTimer(this, EventArgs.Empty);
        }

        private async void uploadSupportFilesButton_Click(object sender, EventArgs e)
        {
            if (!_ftp?.Connected ?? true) return;
            ftpStatusIndicator.BackColor = Color.DodgerBlue;
            await Task.Run(() =>
            {
                var success = false;
                while (!success)
                {
                    success = _ftp.UploadDirectory(_timerPath!);
                }
            });
            ftpStatusIndicator.BackColor = Color.LawnGreen;
        }

        private void buttonLoadLastCredentials_Click(object sender, EventArgs e)
        {
            // TODO: Constants
            textBoxFtpPath.Text = Settings.Read("LAST_FTP_PATH") ?? string.Empty;
            textBoxFtpUsername.Text = Settings.Read("LAST_FTP_USERNAME") ?? string.Empty;
            textBoxFtpPassword.Text = Settings.Read("LAST_FTP_PASSWORD") ?? string.Empty;
        }

        private void resultsIframeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _tournamentTimer.ResultsIframeEnabled =
                resultsIframeVisibilityUpDown.Enabled = iframeSourceTextBox.Enabled =
                    clockVisibilityDurationUpDown.Enabled = resultsIframeVisibilityUpDown.Enabled =
                        selectRoundsButton.Enabled = selectedRoundsLabel.Enabled =
                            enableByDefaultCheckBox.Enabled = resultsIframeCheckBox.Checked;
            _tournamentTimer.OnFileUpdateRequired();
            UpdateSelectedRoundsLabel();
        }

        private void resultsIframeVisibilityUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.ResultsIframeIframeVisibility = (int) resultsIframeVisibilityUpDown.Value;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void clockVisibilityDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.ResultsIframeClockVisibility = (int) clockVisibilityDurationUpDown.Value;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void enableByDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultResultsIframeActive = enableByDefaultCheckBox.Checked;
            _tournamentTimer.OnFileUpdateRequired();
            UpdateSelectedRoundsLabel();
        }

        private void iframeSourceTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.ResultsIframeSource = iframeSourceTextBox.Text;
            _tournamentTimer.OnFileUpdateRequired();
        }

        private void selectRoundsButton_Click(object sender, EventArgs e)
        {
            var rounds = _tournamentTimer.RoundsList.Select((o, i) =>
                new CheckListOption<Round>($"Round {i + 1}" + (o.ResultsIframeActive == null
                    ? " [DEFAULT]"
                    : ""), o)).ToList();

            var roundsSelectDialog = new ChooseFromCheckList<Round>(
                rounds,
                rounds.Where(o => o.Value.ResultsIframeActive ?? _tournamentTimer.DefaultResultsIframeActive)
                    .ToList(),
                "Select rounds", "Select rounds in which results should be shown", true);
            roundsSelectDialog.ShowDialog();

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (roundsSelectDialog.DialogResult == DialogResult.Cancel) return;
            if (roundsSelectDialog.DialogResult == DialogResult.Retry)
            {
                foreach (var round in _tournamentTimer.RoundsList)
                {
                    round.ResultsIframeActive = null;
                }

                _tournamentTimer.OnFileUpdateRequired();
                UpdateSelectedRoundsLabel();
                return;
            }


            foreach (var round in roundsSelectDialog.Selected)
            {
                if (_tournamentTimer.DefaultResultsIframeActive && round.ResultsIframeActive == null)
                {
                    round.ResultsIframeActive = null;
                }
                else
                {
                    round.ResultsIframeActive = true;
                }
            }

            foreach (var round in roundsSelectDialog.NotSelected)
            {
                if (!_tournamentTimer.DefaultResultsIframeActive && round.ResultsIframeActive == null)
                {
                    round.ResultsIframeActive = null;
                }
                else
                {
                    round.ResultsIframeActive = false;
                }
            }

            _tournamentTimer.OnFileUpdateRequired();
            UpdateSelectedRoundsLabel();
        }

        private void UpdateSelectedRoundsLabel()
        {
            var sb = new StringBuilder();
            var enabledRoundsIds = Enumerable.Range(1, _tournamentTimer.RoundsList.Count).Where(i =>
                    _tournamentTimer.RoundsList[i - 1].ResultsIframeActive ??
                    _tournamentTimer.DefaultResultsIframeActive)
                .ToList();

            for (var i = 0; i < enabledRoundsIds.Count; i++)
            {
                var current = enabledRoundsIds[i];
                var previous = enabledRoundsIds.ElementAtOrDefault(i - 1);
                var next = enabledRoundsIds.ElementAtOrDefault(i + 1);
                if (previous == 0)
                {
                    sb.Append(current);
                    continue;
                }

                if (current - previous == 1)
                {
                    if (next - current == 1)
                    {
                        continue;
                    }

                    sb.Append("-");
                    sb.Append(current);
                }
                else
                {
                    sb.Append(", ");
                    sb.Append(current);
                }
            }

            selectedRoundsLabel.Text = "Rounds: " + sb;
        }
    }
}
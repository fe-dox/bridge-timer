using System;
using System.Text.RegularExpressions;
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
            _tournamentTimer.DefaultSettingsChanged += UpdateAfterDefaultSettingsChanged;
            numberOfRoundsUpDown.Value = _tournamentTimer.NumberOfRounds;
            minutesPerRoundUpDown.Value = _tournamentTimer.DefaultRoundDuration;
            breakDurationUpDown.Value = _tournamentTimer.DefaultBreakDuration;
            blinkingDurationUpDown.Value = _tournamentTimer.DefaultBlinkingDuration;
            roundOvertimeCheckBox.Checked = _tournamentTimer.DefaultOvertimeAfterRound;
            timerNameTextBox.Text = _tournamentTimer.DefaultTimerName;
            breakTextTextBox.Text = _tournamentTimer.DefaultBreakText;
            UpdateRounds();
        }

        // TODO This should be in some Utils file. BTW I have to do the same in TC.
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


        private void UpdateColumn(DefaultSettings defaultSettings)
        {
            for (var i = 0; i < roundsDataGridView.Rows.Count; i++)
            {
                var round = _tournamentTimer.RoundsList[i];
                if (defaultSettings switch
                {
                    DefaultSettings.RoundDuration => round.Duration == null,
                    DefaultSettings.BlinkingDuration => round.BlinkingDuration == null,
                    DefaultSettings.AfterRoundOvertime => round.OvertimeAfterRound == null,
                    DefaultSettings.BreakDuration => round.BreakDuration == null,
                    DefaultSettings.BreakText => round.BreakText == null,
                    DefaultSettings.TimerName => round.TimerName == null,
                    DefaultSettings.NumberOfRounds => throw new NotSupportedException(),
                    _ => throw new ArgumentOutOfRangeException()
                } != true) continue;

                // ReSharper disable once HeapView.BoxingAllocation
                roundsDataGridView.Rows[i].Cells[(int) defaultSettings].Value = defaultSettings switch
                {
                    DefaultSettings.RoundDuration => (round.Duration ?? _tournamentTimer.DefaultRoundDurationTimeSpan)
                                                     .TotalSeconds / 60 +
                                                     " m",
                    DefaultSettings.BlinkingDuration => (round.BlinkingDuration ??
                                                         _tournamentTimer.DefaultBlinkingDurationTimeSpan)
                        .TotalSeconds + " s",
                    DefaultSettings.AfterRoundOvertime => round.OvertimeAfterRound ??
                                                          _tournamentTimer.DefaultOvertimeAfterRound,
                    DefaultSettings.BreakDuration => (round.BreakDuration ??
                                                      _tournamentTimer.DefaultBreakDurationTimeSpan).TotalSeconds +
                                                     " s",
                    DefaultSettings.BreakText => round.BreakText ?? _tournamentTimer.DefaultBreakText,
                    DefaultSettings.TimerName => round.TimerName ?? _tournamentTimer.DefaultTimerName,
                    DefaultSettings.NumberOfRounds => throw new NotSupportedException(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private void UpdateAfterDefaultSettingsChanged(object sender, DefaultSettings defaultSettings)
        {
            RunAction(() =>
            {
                switch (defaultSettings)
                {
                    case DefaultSettings.TimerName:
                    case DefaultSettings.BreakText:
                    case DefaultSettings.BreakDuration:
                    case DefaultSettings.BlinkingDuration:
                    case DefaultSettings.AfterRoundOvertime:
                    case DefaultSettings.RoundDuration:
                        UpdateColumn(defaultSettings);
                        break;
                    case DefaultSettings.NumberOfRounds:
                        numberOfRoundsUpDown.Value = _tournamentTimer.NumberOfRounds;
                        UpdateRounds();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(defaultSettings), defaultSettings, null);
                }
            });
        }


        private void AddRoundToDataGridView(Round round)
        {
            var duration = (round.Duration ?? _tournamentTimer.DefaultRoundDurationTimeSpan).TotalSeconds / 60 +
                           " m";
            var blinkingDuration = (round.BlinkingDuration ?? _tournamentTimer.DefaultBlinkingDurationTimeSpan)
                .TotalSeconds + " s";
            var breakDuration =
                (round.BreakDuration ?? _tournamentTimer.DefaultBreakDurationTimeSpan).TotalSeconds + " s";
            var overtime = round.OvertimeAfterRound ?? _tournamentTimer.DefaultOvertimeAfterRound;
            var breakText = round.BreakText ?? _tournamentTimer.DefaultBreakText;
            var timerName = round.TimerName ?? _tournamentTimer.DefaultTimerName;
            roundsDataGridView.Rows.Add(duration, blinkingDuration, overtime, breakDuration, breakText, timerName);
        }

        private void UpdateRounds()
        {
            roundsDataGridView.Rows.Clear();
            foreach (var round in _tournamentTimer.RoundsList)
            {
                AddRoundToDataGridView(round);
            }
        }

        // TODO: Why do you need this function at all? What is it's purpose? Does it achieve single select? If so you can just set MultiSelect to false on dataGridView (it's a property)
        private void roundsDataGridView_MouseDown(object sender, EventArgs eventArgs)
        {
            // TODO: The argument of this function should just be MouseEventArgs
            if (!(eventArgs is MouseEventArgs mouseEventArgs)) return;
            if (mouseEventArgs.Button != MouseButtons.Right) return;
            var hitTestInfo = roundsDataGridView.HitTest(mouseEventArgs.X, mouseEventArgs.Y);
            if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0) return;
            if (roundsDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected) return;
            roundsDataGridView.ClearSelection();
            roundsDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected = true;
        }

        private void setToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewCell cell in roundsDataGridView.SelectedCells)
                {
                    var round = _tournamentTimer.RoundsList[cell.RowIndex];
                    switch (cell.ColumnIndex)
                    {
                        case 0:
                            round.Duration = null;
                            cell.Value = _tournamentTimer.DefaultRoundDuration + " m";
                            break;
                        case 1:
                            round.BlinkingDuration = null;
                            cell.Value = _tournamentTimer.DefaultBlinkingDuration + " s";
                            break;
                        case 2:
                            round.OvertimeAfterRound = null;
                            cell.Value = _tournamentTimer.DefaultOvertimeAfterRound;
                            break;
                        case 3:
                            round.BreakDuration = null;
                            cell.Value = _tournamentTimer.DefaultBreakDuration + " s";
                            break;
                        case 4:
                            round.BreakText = null;
                            cell.Value = _tournamentTimer.DefaultBreakText;
                            break;
                        case 5:
                            round.TimerName = null;
                            cell.Value = _tournamentTimer.DefaultTimerName;
                            break;
                    }
                }
            }
            catch
            {
                // ignore
            }
        }

        private void addRoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nRound = new Round();
            _tournamentTimer.RoundsList.Add(nRound);
            AddRoundToDataGridView(nRound);
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.NumberOfRounds);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in roundsDataGridView.SelectedCells)
            {
                // TODO: Some error message
                if (_tournamentTimer.RoundsList.Count == 1) break;
                try
                {
                    _tournamentTimer.RoundsList.RemoveAt(cell.RowIndex);
                }
                catch
                {
                    // TODO: Some error message
                    // Ignore 
                }
            }

            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.NumberOfRounds);
        }

        private void numberOfRoundsUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.NumberOfRounds = (int) numberOfRoundsUpDown.Value;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.NumberOfRounds);
        }

        private void minutesPerRoundUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultRoundDuration = minutesPerRoundUpDown.Value;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.RoundDuration);
        }

        private void breakDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBreakDuration = (int) breakDurationUpDown.Value;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.BreakDuration);
        }

        private void roundOvertimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultOvertimeAfterRound = roundOvertimeCheckBox.Checked;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.AfterRoundOvertime);
        }

        private void blinkingDurationUpDown_ValueChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBlinkingDuration = (int) blinkingDurationUpDown.Value;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.BlinkingDuration);
        }

        private void timerNameTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultTimerName = timerNameTextBox.Text;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.TimerName);
        }

        private void breakTextTextBox_TextChanged(object sender, EventArgs e)
        {
            _tournamentTimer.DefaultBreakText = breakTextTextBox.Text;
            _tournamentTimer.OnDefaultSettingsChanged(DefaultSettings.BreakText);
        }

        private static bool GetDecimalFromCellValue(string value, out decimal result)
        {
            // TODO: Instead of all this just decimal.TryParse?
            var numbersRegex = new Regex(@"(\d+(\.\d+)?)", RegexOptions.Compiled);
            var match = numbersRegex.Match(value);

            if (!match.Success)
            {
                result = 0;
                return false;
            }

            result = decimal.Parse(match.Value);
            return true;
        }

        private void roundsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // TODO: e.Cancel = false is the default. You don't have to set it.
            decimal result;
            if (_tournamentTimer.RoundsList.Count <= e.RowIndex) return;
            switch (e.ColumnIndex)
            {
                case 0:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        break;
                    }

                    e.Cancel = false;
                    _tournamentTimer.RoundsList[e.RowIndex].Duration =
                        result == _tournamentTimer.DefaultRoundDuration
                            ? (TimeSpan?) null
                            : new TimeSpan(0, 0, (int) (result * 60));
                    break;
                case 1:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        break;
                    }

                    e.Cancel = false;
                    _tournamentTimer.RoundsList[e.RowIndex].BlinkingDuration =
                        result == _tournamentTimer.DefaultBlinkingDuration
                            ? (TimeSpan?) null
                            : new TimeSpan(0, 0, (int) result);
                    break;
                case 2:
                    _tournamentTimer.RoundsList[e.RowIndex].OvertimeAfterRound =
                        (bool) e.FormattedValue == _tournamentTimer.DefaultOvertimeAfterRound
                            ? (bool?) null
                            : (bool) e.FormattedValue;
                    break;
                case 3:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        break;
                    }

                    e.Cancel = false;
                    _tournamentTimer.RoundsList[e.RowIndex].BreakDuration =
                        result == _tournamentTimer.DefaultBreakDuration
                            ? (TimeSpan?) null
                            : new TimeSpan(0, 0, (int) result);
                    break;
                case 4:
                    e.Cancel = false;
                    _tournamentTimer.RoundsList[e.RowIndex].BreakText =
                        e.FormattedValue.ToString() == _tournamentTimer.DefaultBreakText
                            ? null
                            : e.FormattedValue.ToString();
                    break;
                case 5:
                    e.Cancel = false;
                    _tournamentTimer.RoundsList[e.RowIndex].TimerName =
                        e.FormattedValue.ToString() == _tournamentTimer.DefaultTimerName
                            ? null
                            : e.FormattedValue.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
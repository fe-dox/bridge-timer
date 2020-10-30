using System;
using System.Diagnostics;
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
            for (int i = 0; i < roundsDataGridView.Rows.Count; i++)
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
                }) continue;

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
                        UpdateColumn(defaultSettings);
                        break;
                    case DefaultSettings.BreakText:
                        UpdateColumn(defaultSettings);
                        break;
                    case DefaultSettings.BreakDuration:
                        UpdateColumn(defaultSettings);
                        break;
                    case DefaultSettings.BlinkingDuration:
                        UpdateColumn(defaultSettings);
                        break;
                    case DefaultSettings.AfterRoundOvertime:
                        UpdateColumn(defaultSettings);
                        break;
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
            foreach (Round round in _tournamentTimer.RoundsList)
            {
                AddRoundToDataGridView(round);
            }
        }

        private void roundsDataGridView_MouseDown(object sender, EventArgs eventArgs)
        {
            var mouseEventArgs = eventArgs as MouseEventArgs;
            Debug.Assert(mouseEventArgs != null, nameof(mouseEventArgs) + " != null");
            if (mouseEventArgs.Button != MouseButtons.Right) return;
            var hitTestInfo = roundsDataGridView.HitTest(mouseEventArgs.X, mouseEventArgs.Y);
            if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0) return;
            if (roundsDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected) return;
            roundsDataGridView.ClearSelection();
            roundsDataGridView.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex].Selected = true;
        }

        private void setToDefaultToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void addRoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var nRound = new Round();
            _tournamentTimer.RoundsList.Add(nRound);
            AddRoundToDataGridView(nRound);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in roundsDataGridView.SelectedCells)
            {
                try
                {
                    _tournamentTimer.RoundsList.RemoveAt(cell.RowIndex);
                }
                catch
                {
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
            decimal result;
            switch (e.ColumnIndex)
            {
                case 0:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        return;
                    }

                    _tournamentTimer.RoundsList[e.RowIndex].Duration =
                        new TimeSpan(0, 0, (int) (result * 60));
                    e.Cancel = false;
                    break;
                case 1:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        return;
                    }

                    _tournamentTimer.RoundsList[e.RowIndex].BlinkingDuration =
                        new TimeSpan(0, 0, (int) result);
                    e.Cancel = false;

                    break;
                case 2:
                    _tournamentTimer.RoundsList[e.RowIndex].OvertimeAfterRound = (bool) e.FormattedValue;
                    break;
                case 3:
                    if (!GetDecimalFromCellValue(e.FormattedValue.ToString(), out result))
                    {
                        e.Cancel = true;
                        return;
                    }

                    _tournamentTimer.RoundsList[e.RowIndex].BreakDuration =
                        new TimeSpan(0, 0, (int) result);
                    e.Cancel = false;

                    break;
                case 4:
                    _tournamentTimer.RoundsList[e.RowIndex].BreakText = e.FormattedValue.ToString();
                    e.Cancel = false;

                    break;
                case 5:
                    _tournamentTimer.RoundsList[e.RowIndex].TimerName = e.FormattedValue.ToString();
                    e.Cancel = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
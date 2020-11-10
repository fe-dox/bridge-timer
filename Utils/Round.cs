using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    public sealed class Round
    {
        [DataMember] private TimeSpan? _duration;
        [DataMember] private TimeSpan? _breakDuration;
        [DataMember] private TimeSpan? _blinkingDuration;
        [DataMember] private bool? _overtimeAfterRound;
        [DataMember] private string? _breakText;
        [DataMember] private string? _timerName;
        [DataMember] private bool? _resultsIframeActive;

        public bool? ResultsIframeActive
        {
            get => _resultsIframeActive;
            set => _resultsIframeActive = value;
        }

        public TimeSpan? Duration
        {
            get => _duration;
            set
            {
                OnPropertyChanged(value);
                _duration = value;
            }
        }

        public TimeSpan? BreakDuration
        {
            get => _breakDuration;
            set
            {
                OnPropertyChanged(value);
                _breakDuration = value;
            }
        }

        public TimeSpan? BlinkingDuration
        {
            get => _blinkingDuration;
            set
            {
                _blinkingDuration = value;
                OnPropertyChanged(null);
            }
        }

        public bool? OvertimeAfterRound
        {
            get => _overtimeAfterRound;
            set
            {
                _overtimeAfterRound = value;
                OnPropertyChanged(null);
            }
        }

        public string? BreakText
        {
            get => _breakText;
            set
            {
                _breakText = value;
                OnPropertyChanged(null);
            }
        }

        public string? TimerName
        {
            get => _timerName;
            set
            {
                _timerName = value;
                OnPropertyChanged(null);
            }
        }


        public Round(TimeSpan duration, TimeSpan breakDuration, TimeSpan blinkingDuration, bool overtimeAfterRound,
            string breakText, string timerName)
        {
            Duration = duration;
            BreakDuration = breakDuration;
            BlinkingDuration = blinkingDuration;
            OvertimeAfterRound = overtimeAfterRound;
            BreakText = breakText;
            TimerName = timerName;
        }

        public Round()
        {
            Duration = null;
            BreakDuration = null;
            BlinkingDuration = null;
            OvertimeAfterRound = null;
            BreakText = null;
            TimerName = null;
        }

        public event EventHandler<(string, TimeSpan?)>? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(TimeSpan? oldValue, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, (propertyName, oldValue));
        }
    }
}
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    public sealed class Round
    {
        [DataMember] private TimeSpan? _blinkingDuration;
        [DataMember] private TimeSpan? _breakDuration;
        [DataMember] private string? _breakText;
        [DataMember] private TimeSpan? _duration;
        [DataMember] private bool? _overtimeAfterRound;
        [DataMember] private string? _timerName;


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

        [DataMember] public bool? ResultsIframeActive { get; set; }

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
                OnPropertyChanged(value);
            }
        }

        public bool? OvertimeAfterRound
        {
            get => _overtimeAfterRound;
            set
            {
                _overtimeAfterRound = value;
                OnPropertyChanged(value);
            }
        }

        public string? BreakText
        {
            get => _breakText;
            set
            {
                _breakText = value;
                OnPropertyChanged(value);
            }
        }

        public string? TimerName
        {
            get => _timerName;
            set
            {
                _timerName = value;
                OnPropertyChanged(value);
            }
        }

        public event EventHandler<(string, object?)>? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(object? newValue, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, (propertyName, newValue));
        }
    }
}
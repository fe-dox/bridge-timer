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

        public TimeSpan? Duration
        {
            get => _duration;
            set
            {
                OnPropertyChanged(Duration);
                _duration = value;
            }
        }


        public TimeSpan? BreakDuration
        {
            get => _breakDuration;
            set
            {
                OnPropertyChanged(BreakDuration);
                _breakDuration = value;
            }
        }

        [DataMember] public TimeSpan? BlinkingDuration { get; set; }
        [DataMember] public bool? OvertimeAfterRound { get; set; }
        [DataMember] public string? BreakText { get; set; }
        [DataMember] public string? TimerName { get; set; }


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
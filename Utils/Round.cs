using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    // TODO Should this inherit INotifyPropertyChanged?
    public sealed class Round
    {
        [DataMember] private TimeSpan? _blinkingDuration;
        [DataMember] private TimeSpan? _breakDuration;
        [DataMember] private string? _breakText;
        [DataMember] private TimeSpan? _duration;
        [DataMember] private bool? _overtimeAfterRound;
        [DataMember] private bool? _resultsIframeActive;
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

        // TODO: Convert to auto=property?
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
                // TODO: I'm confused. First parameter of OnPropertyChange is called [oldValue]. But here you're using the new value. The same holds true elsewhere (below).
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
                // TODO: Why old value is null? (The same question below)
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

        public event EventHandler<(string, TimeSpan?)>? PropertyChanged;

        // TODO: This has the parameter [oldValue] of type [TimeSpan?] but you're using it for other things as well. I don't understand this design.
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(TimeSpan? oldValue, [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, (propertyName, oldValue));
        }
    }
}
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    public sealed class Round : IEquatable<Round>
    {
        public TimeSpan Duration
        {
            get => _durationFunc?.Invoke() ?? _duration;
            set
            {
                OnPropertyChanged(Duration);
                _durationFunc = null;
                _duration = value;
            }
        }

        public TimeSpan BreakDuration
        {
            get => _breakDurationFunc?.Invoke() ?? _breakDuration;
            set
            {
                OnPropertyChanged(BreakDuration);
                _breakDurationFunc = null;
                _breakDuration = value;
            }
        }

        public TimeSpan BlinkingDuration
        {
            get => _blinkingDurationFunc?.Invoke() ?? _blinkingDuration;
            set
            {
                _blinkingDurationFunc = null;
                _blinkingDuration = value;
            }
        }

        public bool OvertimeAfterRound
        {
            get => _overtimeAfterRoundFunc?.Invoke() ?? _overtimeAfterRound;
            set
            {
                _overtimeAfterRoundFunc = null;
                _overtimeAfterRound = value;
            }
        }

        public string BreakText
        {
            get => _breakTextFunc?.Invoke() ?? _breakText;
            set
            {
                _breakTextFunc = null;
                _breakText = value;
            }
        }

        public string TimerName
        {
            get => _timerNameFunc?.Invoke() ?? _timerName;
            set
            {
                _timerNameFunc = null;
                _timerName = value;
            }
        }

        private bool HasBeenModifiedByUser { get; set; }

        [DataMember] private TimeSpan _duration;
        [DataMember] private TimeSpan _breakDuration;
        [DataMember] private TimeSpan _blinkingDuration;
        [DataMember] private bool _overtimeAfterRound;
        [DataMember] private string _breakText;
        [DataMember] private string _timerName;

        [DataMember] private Func<TimeSpan>? _durationFunc;
        [DataMember] private Func<TimeSpan>? _breakDurationFunc;
        [DataMember] private Func<TimeSpan>? _blinkingDurationFunc;
        [DataMember] private Func<bool>? _overtimeAfterRoundFunc;
        [DataMember] private Func<string>? _breakTextFunc;
        [DataMember] private Func<string>? _timerNameFunc;


        public Round(TimeSpan duration, TimeSpan breakDuration, TimeSpan blinkingDuration, bool overtimeAfterRound,
            string breakText, string timerName, bool hasBeenModifiedByUser)
        {
            _duration = duration;
            _breakDuration = breakDuration;
            _blinkingDuration = blinkingDuration;
            _overtimeAfterRound = overtimeAfterRound;
            _breakText = breakText;
            _timerName = timerName;
            HasBeenModifiedByUser = hasBeenModifiedByUser;
        }

        public Round(Func<TimeSpan> duration, Func<TimeSpan> breakDuration, Func<TimeSpan> blinkingDuration,
            Func<bool> overtimeAfterRound,
            Func<string> breakText, Func<string> timerName, bool hasBeenModifiedByUser)
        {
            _durationFunc = duration;
            _blinkingDurationFunc = blinkingDuration;
            _breakDurationFunc = breakDuration;
            _overtimeAfterRoundFunc = overtimeAfterRound;
            _breakTextFunc = breakText;
            _timerNameFunc = timerName;
            HasBeenModifiedByUser = hasBeenModifiedByUser;
        }

        public bool Equals(Round? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _duration.Equals(other._duration) && _breakDuration.Equals(other._breakDuration) &&
                   _blinkingDuration.Equals(other._blinkingDuration) &&
                   _overtimeAfterRound == other._overtimeAfterRound && _breakText == other._breakText &&
                   _timerName == other._timerName && Equals(_durationFunc, other._durationFunc) &&
                   Equals(_breakDurationFunc, other._breakDurationFunc) &&
                   Equals(_blinkingDurationFunc, other._blinkingDurationFunc) &&
                   Equals(_overtimeAfterRoundFunc, other._overtimeAfterRoundFunc) &&
                   Equals(_breakTextFunc, other._breakTextFunc) && Equals(_timerNameFunc, other._timerNameFunc) &&
                   HasBeenModifiedByUser == other.HasBeenModifiedByUser;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Round) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _duration.GetHashCode();
                hashCode = (hashCode * 397) ^ _breakDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ _blinkingDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ _overtimeAfterRound.GetHashCode();
                hashCode = (hashCode * 397) ^ _breakText.GetHashCode();
                hashCode = (hashCode * 397) ^ _timerName.GetHashCode();
                hashCode = (hashCode * 397) ^ (_durationFunc != null ? _durationFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_breakDurationFunc != null ? _breakDurationFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_blinkingDurationFunc != null ? _blinkingDurationFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^
                           (_overtimeAfterRoundFunc != null ? _overtimeAfterRoundFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_breakTextFunc != null ? _breakTextFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_timerNameFunc != null ? _timerNameFunc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ HasBeenModifiedByUser.GetHashCode();
                return hashCode;
            }
        }

        public event EventHandler<(string, TimeSpan)> PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged(TimeSpan oldValue, [CallerMemberName] string propertyName = null)
        {
            HasBeenModifiedByUser = true;
            PropertyChanged?.Invoke(this, (propertyName, oldValue));
        }
    }
}
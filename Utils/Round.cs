using System;
using System.Runtime.Serialization;

namespace Utils
{
    [DataContract]
    public class Round
    {
        public TimeSpan Duration
        {
            get => _durationFunc?.Invoke() ?? _duration;
            set
            {
                _durationFunc = null;
                _duration = value;
            }
        }

        public TimeSpan BreakDuration
        {
            get => _breakDurationFunc?.Invoke() ?? _breakDuration;
            set
            {
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

        public bool HasBeenModifiedByUser { get; set; }


        [DataMember] private TimeSpan _duration;
        [DataMember] private TimeSpan _breakDuration;
        [DataMember] private TimeSpan _blinkingDuration;
        [DataMember] private bool _overtimeAfterRound;
        [DataMember] private string _breakText;

        [DataMember] private Func<TimeSpan>? _durationFunc;
        [DataMember] private Func<TimeSpan>? _breakDurationFunc;
        [DataMember] private Func<TimeSpan>? _blinkingDurationFunc;
        [DataMember] private Func<bool>? _overtimeAfterRoundFunc;
        [DataMember] private Func<string>? _breakTextFunc;


        public Round(TimeSpan duration, TimeSpan breakDuration, TimeSpan blinkingDuration, bool overtimeAfterRound,
            string breakText, bool hasBeenModifiedByUser)
        {
            _duration = duration;
            _breakDuration = breakDuration;
            _blinkingDuration = blinkingDuration;
            _overtimeAfterRound = overtimeAfterRound;
            _breakText = breakText;
            HasBeenModifiedByUser = hasBeenModifiedByUser;
        }

        public Round(Func<TimeSpan> duration, Func<TimeSpan> breakDuration, Func<TimeSpan> blinkingDuration,
            Func<bool> overtimeAfterRound,
            Func<string> breakText, bool hasBeenModifiedByUser)
        {
            _durationFunc = duration;
            _blinkingDurationFunc = blinkingDuration;
            _breakDurationFunc = breakDuration;
            _overtimeAfterRoundFunc = overtimeAfterRound;
            _breakTextFunc = breakText;
            HasBeenModifiedByUser = hasBeenModifiedByUser;
        }
    }
}
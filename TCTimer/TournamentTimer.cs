using System;
using System.Timers;
using System.Runtime.Serialization;

namespace TCTimer
{
    [DataContract]
    public class TournamentTimer
    {
        [DataMember] private readonly Timer _framesTimer;
        [DataMember] private int _currentRound = 1;
        [DataMember] private float _minutesForRound;
        [DataMember] private DateTime _pausedAtTime;
        [DataMember] private int _secondsForBreak;
        [DataMember] private DateTime _target;


        public TournamentTimer(int numberOfRounds, float minutesForRound, int secondsForBreak)
        {
            NumberOfRounds = numberOfRounds;
            MinutesForRound = minutesForRound;
            SecondsForBreak = secondsForBreak;
            _framesTimer = new Timer(50);
            _framesTimer.Elapsed += OnTick;
            _target = DateTime.Now.Add(RoundTimeSpan());
            _pausedAtTime = DateTime.Now;
        }

        [DataMember] public int NumberOfRounds { get; set; }
        [DataMember] public bool Finished { get; private set; }
        [DataMember] public string BreakText { get; set; } = string.Empty;
        [DataMember] public string ResultsUrl { get; set; } = string.Empty;
        [DataMember] public bool Running { get; private set; }
        [DataMember] public bool IsBreak { get; private set; }

        public float MinutesForRound
        {
            get => _minutesForRound;
            set
            {
                if (!IsBreak)
                {
                    _target = _target.Add(
                        new TimeSpan(0, 0, (int) ((value - _minutesForRound) * 60)));
                }

                _minutesForRound = value;
            }
        }

        public int SecondsForBreak
        {
            get => _secondsForBreak;
            set
            {
                if (IsBreak)
                {
                    _target = _target.Add(new TimeSpan(0, 0, value - _secondsForBreak));
                }

                _secondsForBreak = value;
            }
        }


        public DateTime Target => _target;
        public int CurrentRound => _currentRound;

        public event EventHandler<DateTime> SettingsChanged;
        public event EventHandler<DateTime> Tick;

        private TimeSpan RoundTimeSpan()
        {
            return new TimeSpan(0, 0, (int) (MinutesForRound * 60));
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (_target.Subtract(DateTime.Now).CompareTo(new TimeSpan(0, 0, 0)) < 0)
            {
                if (IsBreak)
                {
                    NextRound();
                }
                else
                {
                    if (_currentRound + 1 > NumberOfRounds)
                    {
                        Finished = true;
                        Pause();
                    }
                    else
                    {
                        _target = DateTime.Now.Add(new TimeSpan(0, 0, SecondsForBreak));
                        IsBreak = true;
                    }
                }
            }

            Tick?.Invoke(this, _target);
        }

        public void Start()
        {
            _target = _target.Add(DateTime.Now.Subtract(_pausedAtTime));
            Running = true;
            Finished = false;
            _framesTimer.Start();
        }

        public void Pause()
        {
            _pausedAtTime = DateTime.Now;
            Running = false;
            _framesTimer.Stop();
        }

        public void AddMinute()
        {
            _target = _target.Add(new TimeSpan(0, 1, 0));
            SettingsChanged?.Invoke(this, Running ? _target : _target.Add(DateTime.Now.Subtract(_pausedAtTime)));
        }

        public void SubtractMinute()
        {
            _target = _target.Subtract(new TimeSpan(0, 1, 0));
            SettingsChanged?.Invoke(this, Running ? _target : _target.Add(DateTime.Now.Subtract(_pausedAtTime)));
        }

        public void NextRound()
        {
            if (_currentRound + 1 > NumberOfRounds)
            {
                Finished = true;
                Pause();
            }
            else
            {
                _target = DateTime.Now.Add(RoundTimeSpan());
                IsBreak = false;
                _currentRound++;
                if (!Running)
                {
                    SettingsChanged?.Invoke(this, _target);
                }
            }
        }

        public void PreviousRound()
        {
            _target = DateTime.Now.Add(RoundTimeSpan());
            if (_currentRound - 1 > 0)
            {
                _currentRound--;
            }

            if (!Running)
            {
                SettingsChanged?.Invoke(this, _target);
            }
        }
    }
}
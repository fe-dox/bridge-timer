﻿using System;
using System.Runtime.Serialization;
using System.Timers;

namespace Utils
{
    [DataContract]
    // TODO Czemu tu jest to [KnownType]? [TimerMessage] nie dziedziczy po [TournamentTimer].
    [KnownType(typeof(TimerMessage))]
    public class TournamentTimer : IEquatable<TournamentTimer>
    {
        [DataMember] private int _currentRound = 1;
        [DataMember] private Timer _framesTimer;
        [DataMember] private float _minutesForRound;
        [DataMember] private DateTime _pausedAtTime;

        [DataMember] private int _secondsForBreak;

        // TODO Chyba nazwalbym to inaczej, np. _nextEventAt, ale nie upieram sie
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
        [DataMember] public string TimerName { get; set; }
        [DataMember] public TimerMessage TimerMessage { get; set; }

        public float MinutesForRound
        {
            get => _minutesForRound;
            set
            {
                if (!IsBreak)
                {
                    // TODO dodawaj minuty zamiast konwertowac do sekund
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

        // TODO mozesz z tego chyba zrobic auto-property
        public DateTime Target => _target;
        public DateTime PausedAtTime => _pausedAtTime;
        public int CurrentRound => _currentRound;

        // TODO dlaczego to jest potrzebne/do czego to uzywasz? Razor tego wymaga?
        public bool Equals(TournamentTimer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _currentRound == other._currentRound && Equals(_framesTimer, other._framesTimer) &&
                   _minutesForRound.Equals(other._minutesForRound) && _pausedAtTime.Equals(other._pausedAtTime) &&
                   _secondsForBreak == other._secondsForBreak && _target.Equals(other._target) &&
                   NumberOfRounds == other.NumberOfRounds && Finished == other.Finished &&
                   BreakText == other.BreakText && ResultsUrl == other.ResultsUrl && Running == other.Running &&
                   IsBreak == other.IsBreak && TimerName == other.TimerName && Equals(TimerMessage, other.TimerMessage);
        }

        public event EventHandler<DateTime> SettingsChanged;

        // TODO [Ticked]
        public event EventHandler<DateTime> Tick;
        public event EventHandler OnFinished;

        private TimeSpan RoundTimeSpan()
        {
            // TODO zamiast konwertowac na sekundy, uzyj minut
            return new TimeSpan(0, 0, (int) (MinutesForRound * 60));
        }

        private void OnTick(object sender, EventArgs e)
        {
            // TODO po prostu [_target < DateTime.Now]
            if (_target.Subtract(DateTime.Now).CompareTo(new TimeSpan(0, 0, 0)) < 0)
            {
                if (IsBreak)
                {
                    NextRound();
                }
                else
                {
                    // TODO [_currentRound >= NumberOfRounds]
                    if (_currentRound + 1 > NumberOfRounds)
                    {
                        Finished = true;
                        Pause();
                        OnFinished?.Invoke(this, null);
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
            // TODO Generalnie + i - beda dzialac tak jak chcesz. Wiec zamiast Add, Substract i takich tam wszedzie lepiej uzywaz znakow.
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
            // TODO ten if jest w duzej mierze podobny do tego w linii 111. W szczegolnosci tam jest OnFinished a tu nie - zgaduje ze tu zapomniales. Czy mozesz zreducowac powtorzenie aby tego uniknac?
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
                _pausedAtTime = DateTime.Now;
                if (!Running)
                {
                    SettingsChanged?.Invoke(this, _target);
                }
            }
        }

        public void PreviousRound()
        {
            _target = DateTime.Now.Add(RoundTimeSpan());
            // TODO [>= 1]? Wydaje mi sie ze latwiej widac o co chodzi
            if (_currentRound - 1 > 0)
            {
                _currentRound--;
            }

            IsBreak = false;

            if (!Running)
            {
                _pausedAtTime = DateTime.Now;
                SettingsChanged?.Invoke(this, _target);
            }
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            _framesTimer = new Timer(50);
            _framesTimer.Elapsed += OnTick;
            if (Running)
            {
                _framesTimer.Start();
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TournamentTimer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // ReSharper disable NonReadonlyMemberInGetHashCode
                var hashCode = _currentRound;
                hashCode = (hashCode * 397) ^ (_framesTimer != null ? _framesTimer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _minutesForRound.GetHashCode();
                hashCode = (hashCode * 397) ^ _pausedAtTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _secondsForBreak;
                hashCode = (hashCode * 397) ^ _target.GetHashCode();
                hashCode = (hashCode * 397) ^ NumberOfRounds;
                hashCode = (hashCode * 397) ^ Finished.GetHashCode();
                hashCode = (hashCode * 397) ^ (BreakText != null ? BreakText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ResultsUrl != null ? ResultsUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Running.GetHashCode();
                hashCode = (hashCode * 397) ^ IsBreak.GetHashCode();
                hashCode = (hashCode * 397) ^ (TimerName != null ? TimerName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (TimerMessage != null ? TimerMessage.GetHashCode() : 0);
                return hashCode;
                // ReSharper enable NonReadonlyMemberInGetHashCode
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Timers;

namespace Utils
{
    [DataContract]
    public class TournamentTimer : IEquatable<TournamentTimer>
    {
        //TODO Podział na domyślne ustawienia rundy, oraz na listę rund
        //TODO Obsługa zmian RoundsList 
        [DataMember] private Timer _framesTimer;
        [DataMember] private float _minutesForRound;
        [DataMember] private int _secondsForBreak;

        public TournamentTimer(int numberOfRounds, float minutesForRound, int secondsForBreak)
        {
            NumberOfRounds = numberOfRounds;
            MinutesForRound = minutesForRound;
            SecondsForBreak = secondsForBreak;
            _framesTimer = new Timer(50);
            _framesTimer.Elapsed += OnTick;
            Target = DateTime.Now + RoundTimeSpan();
            PausedAtTime = DateTime.Now;
        }


        [DataMember]
        public int NumberOfRounds
        {
            get => RoundsList.Count;
            set => ; //TODO: Dodawanie rundy jeśli NumberOfRounds jest mniejszy niż RoundsList.Count
        }

        [DataMember] public bool Finished { get; private set; }
        [DataMember] public string BreakText { get; set; } = string.Empty;
        [DataMember] public string ResultsUrl { get; set; } = string.Empty;
        [DataMember] public bool Running { get; private set; }
        [DataMember] public bool IsBreak { get; private set; }
        [DataMember] public string TimerName { get; set; }
        [DataMember] public TimerMessage TimerMessage { get; set; }
        [DataMember] private List<Round> RoundsList { get; set; }

        public float MinutesForRound
        {
            get => _minutesForRound;
            set
            {
                if (!IsBreak)
                {
                    Target +=
                        new TimeSpan(0, 0, (int) ((value - _minutesForRound) * 60));
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
                    Target += new TimeSpan(0, 0, value - _secondsForBreak);
                }

                _secondsForBreak = value;
            }
        }

        [DataMember] public DateTime Target { get; private set; }
        [DataMember] public DateTime PausedAtTime { get; private set; }
        [DataMember] public int CurrentRound { get; private set; } = 1;

        public bool Equals(TournamentTimer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CurrentRound == other.CurrentRound && Equals(_framesTimer, other._framesTimer) &&
                   _minutesForRound.Equals(other._minutesForRound) && PausedAtTime.Equals(other.PausedAtTime) &&
                   _secondsForBreak == other._secondsForBreak && Target.Equals(other.Target) &&
                   NumberOfRounds == other.NumberOfRounds && Finished == other.Finished &&
                   BreakText == other.BreakText && ResultsUrl == other.ResultsUrl && Running == other.Running &&
                   IsBreak == other.IsBreak && TimerName == other.TimerName && Equals(TimerMessage, other.TimerMessage);
        }

        public event EventHandler<DateTime> SettingsChanged;
        public event EventHandler<DateTime> Ticked;
        public event EventHandler OnFinished;

        private TimeSpan RoundTimeSpan()
        {
            return new TimeSpan(0, 0, (int) (MinutesForRound * 60));
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (Target < DateTime.Now)
            {
                if (IsBreak)
                {
                    NextRound();
                }
                else
                {
                    if (CurrentRound >= NumberOfRounds)
                    {
                        Finished = true;
                        Pause();
                        OnFinished?.Invoke(this, null);
                    }
                    else
                    {
                        Target = DateTime.Now + new TimeSpan(0, 0, SecondsForBreak);
                        IsBreak = true;
                    }
                }
            }

            Ticked?.Invoke(this, Target);
        }

        public void Start()
        {
            Target += DateTime.Now - PausedAtTime;
            Running = true;
            Finished = false;
            _framesTimer.Start();
        }

        public void Pause()
        {
            PausedAtTime = DateTime.Now;
            Running = false;
            _framesTimer.Stop();
        }

        public void AddMinute()
        {
            Target += +new TimeSpan(0, 1, 0);
            SettingsChanged?.Invoke(this, Running ? Target : Target.Add(DateTime.Now.Subtract(PausedAtTime)));
        }

        public void SubtractMinute()
        {
            Target = Target.Subtract(new TimeSpan(0, 1, 0));
            SettingsChanged?.Invoke(this, Running ? Target : Target.Add(DateTime.Now.Subtract(PausedAtTime)));
        }

        public void NextRound()
        {
            // TODO ten if jest w duzej mierze podobny do tego w linii 111. W szczegolnosci tam jest OnFinished a tu nie - zgaduje ze tu zapomniales. Czy mozesz zreducowac powtorzenie aby tego uniknac?
            if (CurrentRound >= NumberOfRounds)
            {
                Finished = true;
                Pause();
            }
            else
            {
                Target = DateTime.Now.Add(RoundTimeSpan());
                IsBreak = false;
                CurrentRound++;
                PausedAtTime = DateTime.Now;
                if (!Running)
                {
                    SettingsChanged?.Invoke(this, Target);
                }
            }
        }

        public void PreviousRound()
        {
            Target = DateTime.Now + RoundTimeSpan();
            if (CurrentRound > 1)
            {
                CurrentRound--;
            }

            IsBreak = false;

            if (!Running)
            {
                PausedAtTime = DateTime.Now;
                SettingsChanged?.Invoke(this, Target);
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
                var hashCode = CurrentRound;
                hashCode = (hashCode * 397) ^ (_framesTimer != null ? _framesTimer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _minutesForRound.GetHashCode();
                hashCode = (hashCode * 397) ^ PausedAtTime.GetHashCode();
                hashCode = (hashCode * 397) ^ _secondsForBreak;
                hashCode = (hashCode * 397) ^ Target.GetHashCode();
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
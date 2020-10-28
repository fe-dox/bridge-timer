using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Timers;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    public class TournamentTimer : IEquatable<TournamentTimer>
    {
        //TODO Obsługa zmian RoundsList 
        [DataMember] private Timer _framesTimer;

        public TournamentTimer(int numberOfRounds, float defaultRoundDuration, int defaultBreakDuration,
            int defaultBlinkingDuration)
        {
            NumberOfRounds = numberOfRounds;
            DefaultRoundDuration = defaultRoundDuration;
            DefaultBreakDuration = defaultBreakDuration;
            DefaultBlinkingDuration = defaultBlinkingDuration;
            RoundsList.CollectionChanged += OnRoundsListChanged;
            _framesTimer = new Timer(50);
            _framesTimer.Elapsed += OnTick;
            Target = DateTime.Now + CurrentRound.Duration;
            PausedAtTime = DateTime.Now;
        }

        private void OnRoundsListChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Round newRound in notifyCollectionChangedEventArgs.NewItems)
                {
                    void OnRoundPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
                    {
                        Console.WriteLine(newRound);
                    }

                    newRound.PropertyChanged += OnRoundPropertyChanged;
                }
            }
            else if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Remove)
            {
            }
        }


        public int NumberOfRounds
        {
            get => RoundsList.Count;
            set
            {
                while (value > RoundsList.Count)
                {
                    RoundsList.Add(CreateDefaultRound());
                }

                while (value < RoundsList.Count && value > CurrentRoundId + 1)
                {
                    RoundsList.RemoveAt(RoundsList.Count - 1);
                }
            }
        }

        [DataMember] public bool Finished { get; private set; }
        [DataMember] public string DefaultBreakText { get; set; } = string.Empty;
        [DataMember] public string DefaultTimerName { get; set; }
        [DataMember] public bool DefaultOvertimeAfterRound { get; set; }
        [DataMember] public string ResultsUrl { get; set; } = string.Empty;
        [DataMember] public bool Running { get; private set; }
        [DataMember] public bool IsBreak { get; private set; }
        [DataMember] public TimerMessage TimerMessage { get; set; }

        [DataMember] private ObservableCollection<Round> RoundsList { get; set; }

        public string BreakText => RoundsList[CurrentRoundId].BreakText;
        public string TimerName => RoundsList[CurrentRoundId].TimerName;
        public TimeSpan BlinkingDuration => RoundsList[CurrentRoundId].BlinkingDuration;

        private TimeSpan DefaultRoundDurationTimeSpanMethod() => new TimeSpan(0, 0, (int) (DefaultRoundDuration * 60));
        private TimeSpan DefaultBreakDurationTimeSpanMethod() => new TimeSpan(0, 0, DefaultBreakDuration);
        private TimeSpan DefaultBlinkingDurationTimeSpanMethod() => new TimeSpan(0, 0, DefaultBlinkingDuration);
        private bool DefaultOvertimeAfterRoundMethod() => DefaultOvertimeAfterRound;
        private string DefaultBreakTextMethod() => DefaultBreakText;
        private string DefaultTimerNameMethod() => DefaultTimerName;

        private Round CurrentRound => RoundsList[CurrentRoundId];

        [DataMember] public int DefaultBlinkingDuration { get; set; }
        [DataMember] public float DefaultRoundDuration { get; set; }
        [DataMember] public int DefaultBreakDuration { get; set; }
        [DataMember] public DateTime Target { get; private set; }
        [DataMember] public DateTime PausedAtTime { get; private set; }
        [DataMember] public int CurrentRoundId { get; private set; } = 0;

        public event EventHandler<DateTime> SettingsChanged;
        public event EventHandler<DateTime> Ticked;
        public event EventHandler OnFinished;

        private void OnTick(object sender, EventArgs e)
        {
            if (Target < DateTime.Now)
            {
                if (IsBreak)
                {
                    GoToNextRound();
                }
                else
                {
                    if (IsFinished()) return;
                    Target = DateTime.Now + new TimeSpan(0, 0, DefaultBreakDuration);
                    IsBreak = true;
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
            Target += new TimeSpan(0, 1, 0);
            SettingsChanged?.Invoke(this, Running ? Target : Target + (DateTime.Now - PausedAtTime));
        }

        public void SubtractMinute()
        {
            Target -= new TimeSpan(0, 1, 0);
            SettingsChanged?.Invoke(this, Running ? Target : Target + (DateTime.Now - PausedAtTime));
        }

        private bool IsFinished()
        {
            if (CurrentRoundId < NumberOfRounds) return false;

            Finished = true;
            OnFinished?.Invoke(this, null);
            Pause();

            return true;
        }

        public void GoToNextRound()
        {
            if (IsFinished()) return;
            IsBreak = false;
            CurrentRoundId++;
            Target = DateTime.Now + CurrentRound.Duration;
            PausedAtTime = DateTime.Now;
            if (!Running)
            {
                SettingsChanged?.Invoke(this, Target);
            }
        }

        public void GoToPreviousRound()
        {
            if (CurrentRoundId > 0)
            {
                CurrentRoundId--;
            }

            Target = DateTime.Now + CurrentRound.Duration;

            IsBreak = false;

            if (Running) return;
            PausedAtTime = DateTime.Now;
            SettingsChanged?.Invoke(this, Target);
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

        private Round CreateDefaultRound()
        {
            // ReSharper disable HeapView.DelegateAllocation
            return new Round(DefaultRoundDurationTimeSpanMethod, DefaultBreakDurationTimeSpanMethod,
                DefaultBlinkingDurationTimeSpanMethod, DefaultOvertimeAfterRoundMethod,
                DefaultBreakTextMethod, DefaultTimerNameMethod, false);
            // ReSharper enable HeapView.DelegateAllocation
        }

        public bool Equals(TournamentTimer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _framesTimer.Equals(other._framesTimer) && Finished == other.Finished &&
                   DefaultBreakText == other.DefaultBreakText && DefaultTimerName == other.DefaultTimerName &&
                   DefaultOvertimeAfterRound == other.DefaultOvertimeAfterRound && ResultsUrl == other.ResultsUrl &&
                   Running == other.Running && IsBreak == other.IsBreak && TimerMessage.Equals(other.TimerMessage) &&
                   RoundsList.Equals(other.RoundsList) && DefaultBlinkingDuration == other.DefaultBlinkingDuration &&
                   DefaultRoundDuration.Equals(other.DefaultRoundDuration) &&
                   DefaultBreakDuration == other.DefaultBreakDuration && Target.Equals(other.Target) &&
                   PausedAtTime.Equals(other.PausedAtTime) && CurrentRoundId == other.CurrentRoundId;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TournamentTimer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _framesTimer.GetHashCode();
                hashCode = (hashCode * 397) ^ Finished.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultBreakText.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultTimerName.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultOvertimeAfterRound.GetHashCode();
                hashCode = (hashCode * 397) ^ ResultsUrl.GetHashCode();
                hashCode = (hashCode * 397) ^ Running.GetHashCode();
                hashCode = (hashCode * 397) ^ IsBreak.GetHashCode();
                hashCode = (hashCode * 397) ^ TimerMessage.GetHashCode();
                hashCode = (hashCode * 397) ^ RoundsList.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultBlinkingDuration;
                hashCode = (hashCode * 397) ^ DefaultRoundDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultBreakDuration;
                hashCode = (hashCode * 397) ^ Target.GetHashCode();
                hashCode = (hashCode * 397) ^ PausedAtTime.GetHashCode();
                hashCode = (hashCode * 397) ^ CurrentRoundId;
                return hashCode;
            }
        }
    }
}
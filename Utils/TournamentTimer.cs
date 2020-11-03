using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Timers;
using Utils.Annotations;

namespace Utils
{
    [DataContract]
    public class TournamentTimer : IEquatable<TournamentTimer>
    {
        private Timer _framesTimer;
        [DataMember] private decimal _defaultRoundDuration;
        [DataMember] private int _defaultBreakDuration;
        [DataMember] private TimerMessage? _timerMessage;
        [DataMember] private string _style = StyleSheet.Default;
        [DataMember] public bool Finished { get; private set; }
        [DataMember] public string DefaultBreakText { get; set; } = string.Empty;
        [DataMember] public string DefaultTimerName { get; set; } = string.Empty;
        [DataMember] public int DefaultBlinkingDuration { get; set; }


        public decimal DefaultRoundDuration
        {
            get => _defaultRoundDuration;
            set
            {
                if (CurrentRound.Duration == null && !IsBreak)
                {
                    Target += new TimeSpan(0, 0, (int) (value * 60)) - DefaultRoundDurationTimeSpan;
                    if (!Running)
                    {
                        SettingsChanged?.Invoke(this, Target + (DateTime.Now - PausedAtTime));
                    }
                }

                _defaultRoundDuration = value;
            }
        }

        public int DefaultBreakDuration
        {
            get => _defaultBreakDuration;
            set
            {
                if (CurrentRound.BreakDuration == null && IsBreak)
                {
                    Target += new TimeSpan(0, 0, value) - DefaultBreakDurationTimeSpan;
                    if (!Running)
                    {
                        SettingsChanged?.Invoke(this, Target + (DateTime.Now - PausedAtTime));
                    }
                }

                _defaultBreakDuration = value;
            }
        }

        public TimerMessage? TimerMessage
        {
            get => _timerMessage;
            set
            {
                _timerMessage = value;
                OnFileUpdateRequired();
            }
        }

        public string Style
        {
            get => _style;
            set
            {
                _style = value;
                OnFileUpdateRequired();
            }
        }

        [DataMember] public bool DefaultOvertimeAfterRound { get; set; }
        [DataMember] public string ResultsUrl { get; set; } = string.Empty;
        [DataMember] public bool Running { get; private set; }
        [DataMember] public bool IsBreak { get; private set; }
        [DataMember] public ObservableCollection<Round> RoundsList { get; set; } = new ObservableCollection<Round>();
        [DataMember] public DateTime Target { get; private set; }
        [DataMember] public DateTime PausedAtTime { get; private set; }
        [DataMember] public int CurrentRoundId { get; private set; }

        public event EventHandler<DateTime>? SettingsChanged;
        public event EventHandler<DateTime>? Ticked;
        public event EventHandler? OnFinished;
        public event EventHandler<DefaultSettings>? DefaultSettingsChanged;
        public event EventHandler? FileUpdateRequired;

        public string BreakText => RoundsList[CurrentRoundId].BreakText ?? DefaultBreakText;
        public string TimerName => RoundsList[CurrentRoundId].TimerName ?? DefaultTimerName;
        public bool Overtime => RoundsList[CurrentRoundId].OvertimeAfterRound ?? DefaultOvertimeAfterRound;

        public TimeSpan BlinkingDuration =>
            RoundsList[CurrentRoundId].BlinkingDuration ?? DefaultBlinkingDurationTimeSpan;

        public TimeSpan DefaultRoundDurationTimeSpan => new TimeSpan(0, 0, (int) (DefaultRoundDuration * 60));
        public TimeSpan DefaultBreakDurationTimeSpan => new TimeSpan(0, 0, DefaultBreakDuration);
        public TimeSpan DefaultBlinkingDurationTimeSpan => new TimeSpan(0, 0, DefaultBlinkingDuration);
        private Round CurrentRound => RoundsList[CurrentRoundId];

        public int NumberOfRounds
        {
            get => RoundsList.Count;
            set
            {
                while (value > RoundsList.Count)
                {
                    RoundsList.Add(new Round());
                }

                while (value < RoundsList.Count && value > CurrentRoundId)
                {
                    RoundsList.RemoveAt(RoundsList.Count - 1);
                }
            }
        }

        public TournamentTimer(int numberOfRounds, decimal defaultRoundDuration, int defaultBreakDuration,
            int defaultBlinkingDuration)
        {
            RoundsList.CollectionChanged += OnRoundsListChanged;
            NumberOfRounds = numberOfRounds;
            DefaultRoundDuration = defaultRoundDuration;
            DefaultBreakDuration = defaultBreakDuration;
            DefaultBlinkingDuration = defaultBlinkingDuration;
            _framesTimer = new Timer(50);
            _framesTimer.Elapsed += OnTick;
            Target = DateTime.Now + (CurrentRound.Duration ?? DefaultRoundDurationTimeSpan);
            PausedAtTime = DateTime.Now;
        }

        private void OnRoundsListChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (Round round in notifyCollectionChangedEventArgs.NewItems)
                    {
                        round.PropertyChanged += RoundPropertyChanged;
                    }

                    if (notifyCollectionChangedEventArgs.NewStartingIndex <= CurrentRoundId &&
                        RoundsList.Count - notifyCollectionChangedEventArgs.NewItems.Count > 0)
                    {
                        CurrentRoundId += notifyCollectionChangedEventArgs.NewItems.Count;
                    }

                    break;
                }

                case NotifyCollectionChangedAction.Remove
                    when notifyCollectionChangedEventArgs.OldStartingIndex <= CurrentRoundId &&
                         notifyCollectionChangedEventArgs.OldStartingIndex +
                         notifyCollectionChangedEventArgs.OldItems.Count > CurrentRoundId:
                {
                    if (notifyCollectionChangedEventArgs.OldStartingIndex >= RoundsList.Count)
                    {
                        CurrentRoundId = RoundsList.Count - 1;
                        IsFinished();
                    }
                    else
                    {
                        CurrentRoundId = notifyCollectionChangedEventArgs.OldStartingIndex;
                    }

                    goto case NotifyCollectionChangedAction.Remove;
                }

                case NotifyCollectionChangedAction.Remove
                    when notifyCollectionChangedEventArgs.OldStartingIndex < CurrentRoundId:
                {
                    CurrentRoundId -= notifyCollectionChangedEventArgs.OldItems.Count;
                    goto case NotifyCollectionChangedAction.Remove;
                }

                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (Round oldRound in notifyCollectionChangedEventArgs.OldItems)
                    {
                        oldRound.PropertyChanged -= RoundPropertyChanged;
                    }

                    break;
                }
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RoundPropertyChanged(object sender, (string, TimeSpan?) valueTuple)
        {
            var (propertyName, newValue) = valueTuple;
            if (!(sender is Round changedRound)) return;


            switch (propertyName)
            {
                case "Duration":
                {
                    if (RoundsList.IndexOf(changedRound) != CurrentRoundId) break;
                    if (IsBreak) break;
                    Target += (newValue ?? DefaultRoundDurationTimeSpan) -
                              (changedRound.Duration ?? DefaultRoundDurationTimeSpan);
                    if (!Running)
                    {
                        SettingsChanged?.Invoke(this, Target + (DateTime.Now - PausedAtTime));
                    }

                    break;
                }
                case "BreakDuration":
                {
                    if (RoundsList.IndexOf(changedRound) != CurrentRoundId) break;
                    if (!IsBreak) break;
                    Target += (newValue ?? DefaultRoundDurationTimeSpan) -
                              (changedRound.BreakDuration ?? DefaultBreakDurationTimeSpan);
                    if (!Running)
                    {
                        SettingsChanged?.Invoke(this, Target + (DateTime.Now - PausedAtTime));
                    }

                    break;
                }
            }

            OnFileUpdateRequired();
        }

        public void OnDefaultSettingsChanged(DefaultSettings defaultSettings)
        {
            DefaultSettingsChanged?.Invoke(this, defaultSettings);
            OnFileUpdateRequired();
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (Target < DateTime.Now)
            {
                if (CurrentRound.OvertimeAfterRound ?? DefaultOvertimeAfterRound && !IsBreak)
                {
                    Ticked?.Invoke(this, Target);
                    return;
                }

                if (IsBreak)
                {
                    GoToNextRound();
                }
                else
                {
                    if (IsFinished()) return;
                    Target = DateTime.Now + (CurrentRound.BreakDuration ?? DefaultBreakDurationTimeSpan);
                    IsBreak = true;
                    OnFileUpdateRequired();
                }
            }

            Ticked?.Invoke(this, Target);
        }

        public void Start()
        {
            if (Finished)
            {
                Target = DateTime.Now + (CurrentRound.Duration ?? DefaultRoundDurationTimeSpan);
            }
            else
            {
                Target += DateTime.Now - PausedAtTime;
            }

            Running = true;
            Finished = false;
            _framesTimer.Start();
            OnFileUpdateRequired();
        }

        public void Pause()
        {
            PausedAtTime = DateTime.Now;
            Running = false;
            _framesTimer.Stop();
            OnFileUpdateRequired();
        }

        public void AddMinute()
        {
            Target += new TimeSpan(0, 1, 0);
            SettingsChanged?.Invoke(this, Running ? Target : Target + (DateTime.Now - PausedAtTime));
            OnFileUpdateRequired();
        }

        public void SubtractMinute()
        {
            Target -= new TimeSpan(0, 1, 0);
            SettingsChanged?.Invoke(this, Running ? Target : Target + (DateTime.Now - PausedAtTime));
            OnFileUpdateRequired();
        }

        private bool IsFinished()
        {
            if (CurrentRoundId + 1 < NumberOfRounds && NumberOfRounds > 0) return false;
            Finished = true;
            Pause();
            OnFinished?.Invoke(this, null);
            OnFileUpdateRequired();
            return true;
        }


        public void GoToNextRound()
        {
            if (IsFinished()) return;
            IsBreak = false;
            CurrentRoundId++;
            Target = DateTime.Now + (CurrentRound.Duration ?? DefaultRoundDurationTimeSpan);
            PausedAtTime = DateTime.Now;
            if (!Running)
            {
                SettingsChanged?.Invoke(this, Target);
            }

            OnFileUpdateRequired();
        }

        public void GoToPreviousRound()
        {
            if (CurrentRoundId > 0 && !IsBreak && !Finished)
            {
                CurrentRoundId--;
            }

            Target = DateTime.Now + (CurrentRound.Duration ?? DefaultRoundDurationTimeSpan);

            IsBreak = false;

            OnFileUpdateRequired();
            if (Running) return;
            PausedAtTime = DateTime.Now;
            SettingsChanged?.Invoke(this, Target);
            OnFileUpdateRequired();
        }

        public void OnFileUpdateRequired()
        {
            FileUpdateRequired?.Invoke(this, EventArgs.Empty);
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


        public bool Equals(TournamentTimer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _defaultRoundDuration == other._defaultRoundDuration &&
                   _defaultBreakDuration == other._defaultBreakDuration && Equals(_timerMessage, other._timerMessage) &&
                   Finished == other.Finished && DefaultBreakText == other.DefaultBreakText &&
                   DefaultTimerName == other.DefaultTimerName &&
                   DefaultBlinkingDuration == other.DefaultBlinkingDuration &&
                   DefaultOvertimeAfterRound == other.DefaultOvertimeAfterRound && ResultsUrl == other.ResultsUrl &&
                   Running == other.Running && IsBreak == other.IsBreak && RoundsList.Equals(other.RoundsList) &&
                   Target.Equals(other.Target) && PausedAtTime.Equals(other.PausedAtTime) &&
                   CurrentRoundId == other.CurrentRoundId;
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
                // ReSharper disable NonReadonlyMemberInGetHashCode
                var hashCode = _defaultRoundDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ _defaultBreakDuration;
                hashCode = (hashCode * 397) ^ (_timerMessage != null ? _timerMessage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Finished.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultBreakText.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultTimerName.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultBlinkingDuration;
                hashCode = (hashCode * 397) ^ DefaultOvertimeAfterRound.GetHashCode();
                hashCode = (hashCode * 397) ^ ResultsUrl.GetHashCode();
                hashCode = (hashCode * 397) ^ Running.GetHashCode();
                hashCode = (hashCode * 397) ^ IsBreak.GetHashCode();
                hashCode = (hashCode * 397) ^ RoundsList.GetHashCode();
                hashCode = (hashCode * 397) ^ Target.GetHashCode();
                hashCode = (hashCode * 397) ^ PausedAtTime.GetHashCode();
                hashCode = (hashCode * 397) ^ CurrentRoundId;
                return hashCode;
            }
        }
    }
}
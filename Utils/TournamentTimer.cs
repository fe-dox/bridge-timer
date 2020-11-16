using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Timers;

namespace Utils
{
    [DataContract]
    public class TournamentTimer : IEquatable<TournamentTimer>
    {
        private Timer _clockTimer;
        [DataMember] private int _defaultBreakDuration;

        [DataMember] private decimal _defaultRoundDuration;
        [DataMember] private int _resultsIframeClockVisibility = 60;
        [DataMember] private bool _resultsIframeEnabled;
        [DataMember] private int _resultsIframeIframeVisibility = 60;
        private Timer _resultsIframeTimer;

        [DataMember] private bool _resultsIframeVisible;
        [DataMember] private string _style = StyleSheet.Default;
        [DataMember] private TimerMessage? _timerMessage;

        public TournamentTimer(int numberOfRounds, decimal defaultRoundDuration, int defaultBreakDuration,
            int defaultBlinkingDuration)
        {
            RoundsList.CollectionChanged += OnRoundsListChanged;
            NumberOfRounds = numberOfRounds;
            DefaultRoundDuration = defaultRoundDuration;
            DefaultBreakDuration = defaultBreakDuration;
            DefaultBlinkingDuration = defaultBlinkingDuration;
            _clockTimer = new Timer(50);
            _clockTimer.Elapsed += OnTick;
            Target = DateTime.Now + (CurrentRound.Duration ?? DefaultRoundDurationTimeSpan);
            PausedAtTime = DateTime.Now;
            _resultsIframeTimer = new Timer(200);
            _resultsIframeTimer.Elapsed += ResultsIframeTimerElapsed;
        }

        [DataMember] public DateTime SerializationTimeStamp { get; private set; } = DateTime.Now;
        [DataMember] public DateTime ResultsIframeTimerTarget { get; private set; }

        public bool ResultsIframeEnabled
        {
            get => _resultsIframeEnabled;
            set
            {
                if (value)
                    _resultsIframeTimer.Start();
                else
                    _resultsIframeTimer.Stop();
                OnFileUpdateRequired();
                _resultsIframeEnabled = value;
            }
        }

        [DataMember] public bool DefaultResultsIframeActive { get; set; }
        [DataMember] public string ResultsIframeSource { get; set; } = string.Empty;

        // TODO: The name is not clear - it doesn't show that it takes the number of seconds. Better name or better type please (the latter would be better).
        public int ResultsIframeIframeVisibility
        {
            get => _resultsIframeIframeVisibility;
            set
            {
                if (_resultsIframeVisible)
                {
                    ResultsIframeTimerTarget += new TimeSpan(0, 0, value - _resultsIframeIframeVisibility);
                }

                _resultsIframeIframeVisibility = value;
            }
        }

        // TODO: The name is not clear - it doesn't show that it takes the number of seconds. Better name or better type please (the latter would be better).
        public int ResultsIframeClockVisibility
        {
            get => _resultsIframeClockVisibility;
            set
            {
                if (!_resultsIframeVisible)
                {
                    ResultsIframeTimerTarget += new TimeSpan(0, 0, value - _resultsIframeClockVisibility);
                }

                _resultsIframeClockVisibility = value;
            }
        }

        [DataMember] public bool Finished { get; private set; }
        [DataMember] public string DefaultBreakText { get; set; } = string.Empty;
        [DataMember] public string DefaultTimerName { get; set; } = string.Empty;
        [DataMember] public int DefaultBlinkingDuration { get; set; }

        // TODO: The name is not clear - it doesn't show that it takes the number of minutes. Better name or better type please (the latter would be better).
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

        // TODO: The name is not clear - it doesn't show that it takes the number of seconds. Better name or better type please (the latter would be better).
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

        public string BreakText => RoundsList[CurrentRoundId].BreakText ?? DefaultBreakText;
        public string TimerName => RoundsList[CurrentRoundId].TimerName ?? DefaultTimerName;
        public bool Overtime => RoundsList[CurrentRoundId].OvertimeAfterRound ?? DefaultOvertimeAfterRound;

        public bool ResultsIframeVisible =>
            (RoundsList[CurrentRoundId].ResultsIframeActive ?? DefaultResultsIframeActive) &&
            !string.IsNullOrWhiteSpace(ResultsIframeSource) && ResultsIframeEnabled && _resultsIframeVisible;

        public bool ResultsIframeEnabledInCurrentRound => ResultsIframeEnabled &&
                                                          (RoundsList[CurrentRoundId].ResultsIframeActive ??
                                                           DefaultResultsIframeActive);

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
                // TODO Enumerable.Range().Select(...)
                while (value > RoundsList.Count)
                {
                    RoundsList.Add(new Round());
                }

                // TODO RoundsList.Take()
                while (value < RoundsList.Count && value > CurrentRoundId)
                {
                    RoundsList.RemoveAt(RoundsList.Count - 1);
                }
            }
        }


        public bool Equals(TournamentTimer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _defaultRoundDuration == other._defaultRoundDuration &&
                   _defaultBreakDuration == other._defaultBreakDuration && Equals(_timerMessage, other._timerMessage) &&
                   _style == other._style && _resultsIframeVisible == other._resultsIframeVisible &&
                   _resultsIframeEnabled == other._resultsIframeEnabled &&
                   _resultsIframeIframeVisibility == other._resultsIframeIframeVisibility &&
                   _resultsIframeClockVisibility == other._resultsIframeClockVisibility &&
                   SerializationTimeStamp.Equals(other.SerializationTimeStamp) &&
                   ResultsIframeTimerTarget.Equals(other.ResultsIframeTimerTarget) &&
                   DefaultResultsIframeActive == other.DefaultResultsIframeActive &&
                   ResultsIframeSource == other.ResultsIframeSource && Finished == other.Finished &&
                   DefaultBreakText == other.DefaultBreakText && DefaultTimerName == other.DefaultTimerName &&
                   DefaultBlinkingDuration == other.DefaultBlinkingDuration &&
                   DefaultOvertimeAfterRound == other.DefaultOvertimeAfterRound && ResultsUrl == other.ResultsUrl &&
                   Running == other.Running && IsBreak == other.IsBreak && RoundsList.Equals(other.RoundsList) &&
                   Target.Equals(other.Target) && PausedAtTime.Equals(other.PausedAtTime) &&
                   CurrentRoundId == other.CurrentRoundId;
        }

        public event EventHandler<DateTime>? SettingsChanged;
        public event EventHandler<DateTime>? Ticked;
        public event EventHandler? OnFinished;
        public event EventHandler<DefaultSettings>? DefaultSettingsChanged;
        public event EventHandler? FileUpdateRequired;

        private void OnRoundsListChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                // TODO Hm, smart! I didn't knew it existed and I wrote it myself. Feel free to remove this TODO once you read it.
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
                // TODO Why don't you care about those?
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
            // TODO Can this happen?
            if (!(sender is Round changedRound)) return;


            switch (propertyName)
            {
                // TODO I would prefare [nameof(Round.Duration)] - then if the name of Round.Duration changes this code will still work.
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
            _clockTimer.Start();
            OnFileUpdateRequired();
        }

        public void Pause()
        {
            PausedAtTime = DateTime.Now;
            Running = false;
            _clockTimer.Stop();
            OnFileUpdateRequired();
        }

        // TODO Those two functions are very similar. Refactor?
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

            // TODO: Why do you need to call this twice?
            OnFileUpdateRequired();
            if (Running) return;
            PausedAtTime = DateTime.Now;
            SettingsChanged?.Invoke(this, Target);
            OnFileUpdateRequired();
        }

        private void ResultsIframeTimerElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (ResultsIframeTimerTarget >= DateTime.Now) return;

            ResultsIframeTimerTarget = DateTime.Now + new TimeSpan(0, 0,
                _resultsIframeVisible ? ResultsIframeClockVisibility : ResultsIframeIframeVisibility);
            _resultsIframeVisible = !_resultsIframeVisible;
            if (RoundsList[CurrentRoundId].ResultsIframeActive ?? DefaultResultsIframeActive) OnFileUpdateRequired();
        }

        public void OnFileUpdateRequired()
        {
            FileUpdateRequired?.Invoke(this, EventArgs.Empty);
        }

        [OnSerializing]
        internal void OnSerializing(StreamingContext context)
        {
            SerializationTimeStamp = DateTime.Now;
        }

        [OnDeserialized]
        internal void OnDeserialized(StreamingContext context)
        {
            // TODO: Code repetition with the constructor. Factor out [initializeTimers]?
            _clockTimer = new Timer(50);
            _clockTimer.Elapsed += OnTick;
            if (Running)
            {
                _clockTimer.Start();
            }

            _resultsIframeTimer = new Timer(200);
            _resultsIframeTimer.Elapsed += ResultsIframeTimerElapsed;
            if (ResultsIframeEnabled)
            {
                _resultsIframeTimer.Start();
            }
        }

        public override bool Equals(object? obj)
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
                var hashCode = _defaultRoundDuration.GetHashCode();
                hashCode = (hashCode * 397) ^ _defaultBreakDuration;
                hashCode = (hashCode * 397) ^ (_timerMessage != null ? _timerMessage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _style.GetHashCode();
                hashCode = (hashCode * 397) ^ _resultsIframeVisible.GetHashCode();
                hashCode = (hashCode * 397) ^ _resultsIframeEnabled.GetHashCode();
                hashCode = (hashCode * 397) ^ _resultsIframeIframeVisibility;
                hashCode = (hashCode * 397) ^ _resultsIframeClockVisibility;
                hashCode = (hashCode * 397) ^ SerializationTimeStamp.GetHashCode();
                hashCode = (hashCode * 397) ^ ResultsIframeTimerTarget.GetHashCode();
                hashCode = (hashCode * 397) ^ DefaultResultsIframeActive.GetHashCode();
                hashCode = (hashCode * 397) ^ ResultsIframeSource.GetHashCode();
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
                // ReSharper enable NonReadonlyMemberInGetHashCode
            }
        }
    }
}
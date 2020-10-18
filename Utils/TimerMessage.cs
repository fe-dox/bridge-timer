using System;
using System.Runtime.Serialization;

namespace Utils
{
    [DataContract]
    public class TimerMessage : IEquatable<TimerMessage>
    {
        [DataMember] private TimeSpan _duration;
        [DataMember] private DateTime _expiration;
        [DataMember] private Guid _id;
        [DataMember] private bool _showFullScreen;

        [DataMember] private string _text;

        public TimerMessage(string text, TimeSpan duration, DateTime expiration, bool showFullScreen)
        {
            _text = text;
            _duration = duration;
            _expiration = expiration;
            _showFullScreen = showFullScreen;
            _id = Guid.NewGuid();
        }

        // TODO auto-properties?
        // [field: DataMember] public string Text { get; }
        public string Text => _text;
        public TimeSpan Duration => _duration;
        public DateTime Expiration => _expiration;

        public bool ShowFullScreen => _showFullScreen;

        public bool Equals(TimerMessage other)
        {
            if (other == null)
            {
                return false;
            }

            return Text == other.Text && Expiration.Equals(other.Expiration) && Duration.Equals(other.Duration) &&
                   _id == other._id && _showFullScreen == other._showFullScreen;
        }
    }
}
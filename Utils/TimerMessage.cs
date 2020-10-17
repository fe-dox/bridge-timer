using System;
using System.Runtime.Serialization;

namespace Utils
{
    [DataContract]
    public class TimerMessage : IEquatable<TimerMessage>
    {
        public string Text => _text;
        public TimeSpan Duration => _duration;
        public DateTime Expiration => _expiration;

        public bool ShowFullScreen => _showFullScreen;

        [DataMember] private string _text;
        [DataMember] private bool _showFullScreen;
        [DataMember] private TimeSpan _duration;
        [DataMember] private DateTime _expiration;
        [DataMember] private Guid _id;

        public bool Equals(TimerMessage other)
        {
            return Text == other.Text && Expiration.Equals(other.Expiration) && Duration.Equals(other.Duration) &&
                   _id == other._id && _showFullScreen == other._showFullScreen;
        }

        public TimerMessage(string text, TimeSpan duration, DateTime expiration, bool showFullScreen)
        {
            _text = text;
            _duration = duration;
            _expiration = expiration;
            _showFullScreen = showFullScreen;
            _id = Guid.NewGuid();
        }
    }
}
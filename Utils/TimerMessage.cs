using System;
using System.Runtime.Serialization;

namespace Utils
{
    [DataContract]
    // TODO You need more equality members, also implemented in slightly different way. I added them. This is important to understand, feel free to ask questions if you want me to explain.
    public class TimerMessage : IEquatable<TimerMessage>
    {
        [DataMember] private Guid _id;

        public TimerMessage(string text, TimeSpan duration, DateTime expiration, bool showFullScreen)
        {
            Text = text;
            Duration = duration;
            Expiration = expiration;
            ShowFullScreen = showFullScreen;
            _id = Guid.NewGuid();
        }

        [DataMember] public string Text { get; private set; }
        [DataMember] public TimeSpan Duration { get; private set; }
        [DataMember] public DateTime Expiration { get; private set; }
        [DataMember] public bool ShowFullScreen { get; private set; }

        public bool Equals(TimerMessage? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _id.Equals(other._id) && Text == other.Text && Duration.Equals(other.Duration) &&
                   Expiration.Equals(other.Expiration) && ShowFullScreen == other.ShowFullScreen;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TimerMessage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _id.GetHashCode();
                hashCode = (hashCode * 397) ^ Text.GetHashCode();
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ Expiration.GetHashCode();
                hashCode = (hashCode * 397) ^ ShowFullScreen.GetHashCode();
                return hashCode;
            }
        }
    }
}
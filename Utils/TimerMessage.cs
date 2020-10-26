using System;
using System.Runtime.Serialization;

namespace Utils
{
    [DataContract]
    public class TimerMessage : IEquatable<TimerMessage>
    {
        [DataMember] public string Text { get; private set; }
        [DataMember] public TimeSpan Duration { get; private set; }
        [DataMember] public DateTime Expiration { get; private set; }
        [DataMember] public bool ShowFullScreen { get; private set; }
        [DataMember] private Guid _id;

        public TimerMessage(string text, TimeSpan duration, DateTime expiration, bool showFullScreen)
        {
            Text = text;
            Duration = duration;
            Expiration = expiration;
            ShowFullScreen = showFullScreen;
            _id = Guid.NewGuid();
        }

        public bool Equals(TimerMessage other)
        {
            if (other == null)
            {
                return false;
            }

            return Text == other.Text && Expiration.Equals(other.Expiration) && Duration.Equals(other.Duration) &&
                   _id == other._id && ShowFullScreen == other.ShowFullScreen;
        }
    }
}
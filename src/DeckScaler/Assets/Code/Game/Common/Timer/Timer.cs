using System;
using DeckScaler.Service;

namespace DeckScaler
{
    public readonly struct Timer
    {
        private readonly float _endTimeStamp;

        public Timer(TimeSpan duration) : this((float)duration.TotalSeconds) { }

        public Timer(float seconds)
        {
            _endTimeStamp = Time.CurrentTime + seconds;
        }

        private static ITime Time => ServiceLocator.Resolve<ITime>();

        public bool IsElapsed => Time.CurrentTime >= _endTimeStamp;

        private float TimeLeft => _endTimeStamp - Time.CurrentTime;

        public override string ToString() => $"time left: {TimeLeft}";
    }
}
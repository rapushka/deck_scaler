using System;
using DeckScaler.Service;

namespace DeckScaler
{
    public readonly struct Timer
    {
        private readonly float _endTimeStamp;

        public Timer(TimeSpan duration)
        {
            _endTimeStamp = Time.CurrentTime + (float)duration.TotalSeconds;
        }

        private static ITime Time => Services.Get<ITime>();

        public bool IsElapsed => Time.CurrentTime >= _endTimeStamp;
    }
}
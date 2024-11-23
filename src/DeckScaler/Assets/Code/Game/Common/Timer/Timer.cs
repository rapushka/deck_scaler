using System;
using System.Globalization;
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

        private static ITime Time => Services.Get<ITime>();

        public bool IsElapsed => Time.CurrentTime >= _endTimeStamp;

        private float TimeBeforeElapse => Time.CurrentTime - _endTimeStamp;

        public override string ToString() => TimeBeforeElapse.ToString(CultureInfo.InvariantCulture);
    }
}
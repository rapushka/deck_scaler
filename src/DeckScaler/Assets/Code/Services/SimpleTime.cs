namespace DeckScaler.Service
{
    public interface ITime : IService
    {
        float CurrentTime { get; }

        float DeltaTime { get; }

        float DeltaRealTime { get; }
    }

    public class SimpleTime : ITime
    {
        public float CurrentTime   => UnityEngine.Time.time;
        public float DeltaTime     => UnityEngine.Time.deltaTime;
        public float DeltaRealTime => UnityEngine.Time.unscaledDeltaTime;
    }
}
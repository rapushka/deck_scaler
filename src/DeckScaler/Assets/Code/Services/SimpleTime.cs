namespace DeckScaler.Service
{
    public interface ITime : IService
    {
        float CurrentTime { get; }

        float DeltaTime { get; }

        float DeltaRealTime { get; }

        int Frame { get; }
    }

    public class SimpleTime : ITime
    {
        public float CurrentTime   => UnityEngine.Time.time;
        public float DeltaTime     => UnityEngine.Time.deltaTime;
        public float DeltaRealTime => UnityEngine.Time.unscaledDeltaTime;

        public int Frame => UnityEngine.Time.frameCount;
    }
}
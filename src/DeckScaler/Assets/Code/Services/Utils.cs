namespace DeckScaler.Service
{
    public interface IUtils : IService
    {
        MapUtils Map { get; }

        void Initialize();
        void Dispose();
    }

    public class Utils : IUtils
    {
        public MapUtils Map { get; private set; }

        public void Initialize()
        {
            Map = new();
        }

        public void Dispose()
        {
            Map = null;
        }
    }
}
namespace DeckScaler.Service
{
    public interface IUtils : IService
    {
        MapUtils   Map    { get; }
        StagesUtil Stages { get; }

        void Initialize();
        void Dispose();
    }

    public class Utils : IUtils
    {
        public MapUtils   Map    { get; private set; }
        public StagesUtil Stages { get; private set; }

        public void Initialize()
        {
            Map = new();
            Stages = new();
        }

        public void Dispose()
        {
            Map = null;
            Stages = null;
        }
    }
}
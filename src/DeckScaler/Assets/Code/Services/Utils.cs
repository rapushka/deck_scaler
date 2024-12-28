namespace DeckScaler.Service
{
    public interface IUtils : IService
    {
        MapUtils   Map    { get; }
        StagesUtil Stages { get; }
        UnitsUtil  Units  { get; }

        void Initialize();
        void Dispose();
    }

    public class Utils : IUtils
    {
        public MapUtils   Map    { get; private set; }
        public StagesUtil Stages { get; private set; }
        public UnitsUtil  Units  { get; private set; }

        public void Initialize()
        {
            Map = new();
            Stages = new();
            Units = new();
        }

        public void Dispose()
        {
            Map = null;
            Units = null;
        }
    }
}
namespace DeckScaler.Service
{
    public interface IUtils : IService
    {
        UnitUtils Units { get; }

        void Initialize();
        void Dispose();
    }

    public class Utils : IUtils
    {
        public UnitUtils Units { get; private set; }

        public void Initialize()
        {
            Units = new();
        }

        public void Dispose()
        {
            Units = null;
        }
    }
}
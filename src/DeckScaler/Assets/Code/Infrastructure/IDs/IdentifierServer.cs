using DeckScaler.Service;

namespace DeckScaler
{
    public interface IIdentifierServer : IService
    {
        int Next();

        void Reset();
    }

    public class IdentifierServer : IIdentifierServer
    {
        private int _counter;

        public int Next() => _counter++;

        public void Reset() => _counter = 0;
    }
}
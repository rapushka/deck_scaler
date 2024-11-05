namespace DeckScaler.Service
{
    public interface IDebug : IService
    {
        void Assert(bool condition);
        void Log(string category, string msg);
    }

    public class DebugMock : IDebug
    {
        public void Assert(bool condition) { }

        public void Log(string category, string msg) { }
    }
}
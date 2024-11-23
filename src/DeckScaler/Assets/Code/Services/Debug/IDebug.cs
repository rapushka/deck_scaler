using JetBrains.Annotations;

namespace DeckScaler.Service
{
    public interface IDebug : IService
    {
        void Assert(bool condition);

        void Log(string category, string msg);

        void LogError(string category, string msg);
    }

    [UsedImplicitly] // Actually it used in production builds
    public class DebugMock : IDebug
    {
        public void Assert(bool condition)                { }
        public void Log(string category, string msg)      { }
        public void LogError(string category, string msg) { }
    }
}
namespace DeckScaler.Service
{
    public class Debug : IDebug
    {
        public void Assert(bool condition)
        {
            UnityEngine.Debug.Assert(condition);
        }

        public void Log(string category, string msg)
        {
            // TODO: Categories
            UnityEngine.Debug.Log($"[category] {msg}");
        }
    }
}
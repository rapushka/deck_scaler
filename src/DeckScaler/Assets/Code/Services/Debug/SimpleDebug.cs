using UnityEngine;

namespace DeckScaler.Service
{
    public class SimpleDebug : IDebug
    {
        private ITime Time => ServiceLocator.Resolve<ITime>();

        public void Assert(bool condition)
        {
            Debug.Assert(condition);
        }

        public void Log(string category, string msg)
        {
            Debug.Log(Format(category, msg));
        }

        public void LogError(string category, string msg)
        {
            Debug.LogError(Format(category, msg));
        }

        public void LogWarning(string category, string msg)
        {
            Debug.LogWarning(Format(category, msg));
        }

        private string Format(string category, string msg)
            => $"|{Time.Frame}| [{category}] {msg}\n\n---\n";
    }
}
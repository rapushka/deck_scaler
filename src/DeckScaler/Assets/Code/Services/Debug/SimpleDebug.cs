using UnityEngine;

namespace DeckScaler.Service
{
    public class SimpleDebug : IDebug
    {
        public void Assert(bool condition)
        {
            Debug.Assert(condition);
        }

        public void Log(string category, string msg)
        {
            // TODO: Categories
            Debug.Log($"[{category}] {msg}");
        }

        public void LogError(string category, string msg)
        {
            // TODO: Categories
            Debug.LogError($"[{category}] {msg}");
        }
    }
}
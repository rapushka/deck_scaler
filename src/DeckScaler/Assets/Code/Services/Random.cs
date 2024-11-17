using UnityRandom = UnityEngine.Random;

namespace DeckScaler.Service
{
    public class Random : IService
    {
        public int RandomIndex<T>(T[] array)
        {
            return UnityRandom.Range(0, array.Length);
        }
    }
}
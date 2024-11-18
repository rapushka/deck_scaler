using UnityRandom = UnityEngine.Random;

namespace DeckScaler.Service
{
    public interface IRandom : IService
    {
        int RandomIndex<T>(T[] array);
    }

    public class Random : IRandom
    {
        public int RandomIndex<T>(T[] array)
        {
            return UnityRandom.Range(0, array.Length);
        }
    }
}
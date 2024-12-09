using System.Collections.Generic;
using System.Linq;
using UnityRandom = UnityEngine.Random;

namespace DeckScaler.Service
{
    public interface IRandom : IService
    {
        T PickRandom<T>(IEnumerable<T> source);
    }

    public class SimpleRandom : IRandom
    {
        public T PickRandom<T>(IEnumerable<T> source)
        {
            var array = source as T[] ?? source.ToArray();
            var randomIndex = RandomIndex(array);

            return array[randomIndex];
        }

        public int RandomIndex<T>(T[] array) => UnityRandom.Range(0, array.Length);
    }
}
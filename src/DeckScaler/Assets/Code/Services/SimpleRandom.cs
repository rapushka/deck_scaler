using System.Collections.Generic;
using System.Linq;
using UnityRandom = UnityEngine.Random;

namespace DeckScaler.Service
{
    public interface IRandom : IService
    {
        T   PickRandom<T>(IEnumerable<T> source);
        int RandomNumber(int minInclusive, int maxInclusive);
    }

    public class SimpleRandom : IRandom
    {
        public T PickRandom<T>(IEnumerable<T> source)
        {
            var array = source as T[] ?? source.ToArray();
            var randomIndex = RandomIndex(array);

            return array[randomIndex];
        }

        public int RandomNumber(int minInclusive, int maxInclusive) => UnityRandom.Range(minInclusive, maxInclusive + 1);

        public int RandomIndex<T>(T[] array) => UnityRandom.Range(0, array.Length);
    }
}
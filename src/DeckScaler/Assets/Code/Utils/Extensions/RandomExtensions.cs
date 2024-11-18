using System.Collections.Generic;
using System.Linq;
using DeckScaler.Service;

namespace DeckScaler
{
    public static class RandomExtensions
    {
        public static T PickRandom<T>(this IEnumerable<T> @this)
        {
            var array = @this as T[] ?? @this.ToArray();
            var randomIndex = Services.Get<IRandom>().RandomIndex(array);

            return array[randomIndex];
        }
    }
}
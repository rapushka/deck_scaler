using System.Collections.Generic;
using System.Linq;

namespace DeckScaler
{
    public static class RandomExtensions
    {
        public static T PickRandom<T>(this IEnumerable<T> @this)
        {
            var array = @this as T[] ?? @this.ToArray();
            var randomIndex = Services.Get<Service.Random>().RandomIndex(array);

            return array[randomIndex];
        }
    }
}
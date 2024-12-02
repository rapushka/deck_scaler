using System.Collections.Generic;

namespace DeckScaler
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string @this) => string.IsNullOrWhiteSpace(@this);

        public static string JoinString<T>(this IEnumerable<T> @this, char separator = ' ')                       => string.Join(separator, @this);
        public static string JoinString<TKey, TValue>(this IDictionary<TKey, TValue> @this, char separator = ' ') => string.Join(separator, @this);
    }
}
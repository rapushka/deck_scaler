using System.Collections.Generic;

namespace DeckScaler
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string @this) => string.IsNullOrWhiteSpace(@this);

        public static string JoinString<T>(this IEnumerable<T> @this, char separator = ' ')                       => string.Join(separator, @this);
        public static string JoinString<TKey, TValue>(this IDictionary<TKey, TValue> @this, char separator = ' ') => string.Join(separator, @this);

        public static string Remove(this string source, string oldString) => source.Replace(oldString, string.Empty);

        public static string Format(this string template, object arg0)              => string.Format(template, arg0);
        public static string Format(this string template, object arg0, object arg1) => string.Format(template, arg0, arg1);
        public static string Format(this string template, params object[] args)     => string.Format(template, args);
    }
}
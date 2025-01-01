using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckScaler
{
    public static class LinqExtensions
    {
        // ReSharper disable PossibleMultipleEnumeration - FUCK YOU!
        public static int MaxOrDefault<T>(this IEnumerable<T> @this, Func<T, int> selector, int defaultValue = default)
            => !@this.Any() ? defaultValue : @this.Max(selector);

        public static T FirstOr<T>(this IEnumerable<T> @this, T @default)
            => @this.Any() ? @this.First() : @default;
    }
}
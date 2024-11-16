using System;
using System.Collections.Generic;

namespace DeckScaler
{
	public static class DictionaryExtension
	{
		public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key, Func<TValue> newValue)
		{
			if (@this.TryGetValue(key, out var value))
				return value;

			value = newValue.Invoke();
			@this.Add(key, value);
			return value;
		}
	}
}
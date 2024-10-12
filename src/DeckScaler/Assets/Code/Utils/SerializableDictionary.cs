using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Utils
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        [SerializeField] private Entry[] _values;

        private Dictionary<TKey, TValue> _dictionary;

        private Dictionary<TKey, TValue> Dictionary => _dictionary
            ??= _values.ToDictionary(e => e.Key, e => e.Value);

        public TValue this[TKey key] => Dictionary[key];

        public ICollection<TKey>   Keys   => Dictionary.Keys;
        public ICollection<TValue> Values => Dictionary.Values;

        public int Count => Dictionary.Count;

        public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);

        public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [Serializable]
        private struct Entry
        {
            public TKey Key;
            public TValue Value;
        }
    }
}
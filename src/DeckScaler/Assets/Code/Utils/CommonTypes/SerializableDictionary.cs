using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeckScaler.Utils
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        [SerializeField] private Entry[] _values;

        private Dictionary<TKey, TValue> _dictionary;

        private Dictionary<TKey, TValue> Dictionary => _dictionary
            ??= _values.ToDictionary(e => e.Key, e => e.Value);

        public TValue this[TKey key]
        {
            get => Dictionary[key];
            set => Dictionary[key] = value;
        }

        public ICollection<TKey>   Keys   => Dictionary.Keys;
        public ICollection<TValue> Values => Dictionary.Values;

        public int  Count      => Dictionary.Count;
        public bool IsReadOnly => false;

        public bool Contains(KeyValuePair<TKey, TValue> item) => Dictionary.Contains(item);

        public bool ContainsKey(TKey key) => Dictionary.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value) => Dictionary.TryGetValue(key, out value);

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Add(TKey key, TValue value) => Dictionary.Add(key, value);

        public void Clear() => Dictionary.Clear();

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => throw new NotImplementedException();

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);
        public bool Remove(TKey key)                        => Dictionary.Remove(key);

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
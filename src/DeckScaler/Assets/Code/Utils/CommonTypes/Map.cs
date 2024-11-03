using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public abstract class Map<TKey, TValue>
    {
        [SerializeField] private TValue[] _values;

        private Dictionary<TKey, TValue> _dictionary;

        public Dictionary<TKey, TValue> Dictionary => _dictionary ??= _values.ToDictionary(SelectKey);

        public IEnumerable<TValue> Values => _values;

        public TValue this[TKey key] => Dictionary[key];

        protected abstract TKey SelectKey(TValue value);
    }
}
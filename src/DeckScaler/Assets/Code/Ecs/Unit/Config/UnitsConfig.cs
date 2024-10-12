using System;
using System.Collections.Generic;
using System.Linq;
using Code.Utils;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class UnitsConfig : ScriptableObject
    {
        [SerializeField] private Entry[] _entries;
        [field: SerializeField] public EntityBehaviour UnitViewPrefab { get; private set; }

        public Entry this[string id] => Dictionary[id];

        private Dictionary<string, Entry> _dictionary;
        private Dictionary<string, Entry> Dictionary => _dictionary ??= CollectToDictionary();

        private Dictionary<string, Entry> CollectToDictionary() => _entries.ToDictionary(e => e.ID, e => e);

        [Serializable]
        public class Entry
        {
            [field: SerializeField] public string ID       { get; private set; }
            [field: SerializeField] public Sprite Portrait { get; private set; }
        }
    }
}
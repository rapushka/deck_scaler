using System;
using System.Collections.Generic;
using System.Linq;
using DeckScaler.Utils;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class UnitsConfig : ScriptableObject
    {
        [SerializeField] private UnitConfigMap _unitConfigsMap;

        [field: SerializeField] public ViewEntityBehaviour                  UnitViewPrefab  { get; private set; }
        [field: SerializeField] public SerializableDictionary<Suit, Sprite> CardBackgrounds { get; private set; }

        public UnitConfig this[string id] => _unitConfigsMap[id];

        public IEnumerable<UnitConfig> Leads   => UnitsOfType(UnitType.Lead);
        public IEnumerable<UnitConfig> Allies  => UnitsOfType(UnitType.Ally);
        public IEnumerable<UnitConfig> Enemies => UnitsOfType(UnitType.Enemy);

        private IEnumerable<UnitConfig> UnitsOfType(UnitType unitType)
            => _unitConfigsMap.Values.Where(c => c.Type == unitType);

        [Serializable]
        public class UnitConfig
        {
            [field: SerializeField] public string    ID           { get; private set; }
            [field: SerializeField] public UnitType  Type         { get; private set; }
            [field: SerializeField] public Sprite    Portrait     { get; private set; }
            [field: SerializeField] public int       Health       { get; private set; }
            [field: SerializeField] public Suit      Suit         { get; private set; }
            [field: SerializeField] public StatsData StatsData    { get; private set; }
            [field: SerializeField] public string[]  RelatedCards { get; private set; }
        }

        [Serializable]
        private class UnitConfigMap : Map<string, UnitConfig>
        {
            protected override string SelectKey(UnitConfig value) => value.ID;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class UnitsConfig : ScriptableObject
    {
        [SerializeField] private UnitConfigMap _unitConfigsMap;

        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        public UnitConfig this[string id] => _unitConfigsMap[id];

        public IEnumerable<UnitConfig> Leads   => UnitsOfType(UnitType.Lead);
        public IEnumerable<UnitConfig> Allies  => UnitsOfType(UnitType.Ally);
        public IEnumerable<UnitConfig> Enemies => UnitsOfType(UnitType.Enemy);

        private IEnumerable<UnitConfig> UnitsOfType(UnitType unitType)
            => _unitConfigsMap.Values.Where(c => c.Type == unitType);

        [Serializable]
        public class UnitConfig
        {
            [field: IdRef(startsWith: Constants.TableID.Units)]
            [field: SerializeField] public string ID { get; private set; }

            [field: SerializeField] public UnitType  Type      { get; private set; }
            [field: SerializeField] public int       Health    { get; private set; }
            [field: SerializeField] public Suit      Suit      { get; private set; }
            [field: SerializeField] public StatsData StatsData { get; private set; }
        }

        [Serializable]
        private class UnitConfigMap : Map<string, UnitConfig>
        {
            protected override string SelectKey(UnitConfig value) => value.ID;
        }
    }
}
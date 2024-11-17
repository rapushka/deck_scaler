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
        private class UnitConfigMap : Map<string, UnitConfig>
        {
            protected override string SelectKey(UnitConfig value) => value.ID;
        }
    }
}
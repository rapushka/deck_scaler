using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class UnitsConfig : ScriptableObject
    {
        [SerializeField] private UnitConfigMap _unitConfigsMap;

        [field: SerializeField] public float           DelayBetweenAttacks { get; private set; }
        [field: SerializeField] public EntityBehaviour ViewPrefab          { get; private set; }

        public UnitConfig this[string id] => _unitConfigsMap[id];

        public IEnumerable<UnitConfig> Leads   => UnitsOfType(UnitType.Lead);
        public IEnumerable<UnitConfig> Allies  => UnitsOfType(UnitType.Ally);
        public IEnumerable<UnitConfig> Enemies => UnitsOfType(UnitType.Enemy);

        private IEnumerable<UnitConfig> UnitsOfType(UnitType unitType)
            => _unitConfigsMap.Values.Where(c => c.Type == unitType);

        public bool TryGetUnitType(string unitID, out UnitType unitType)
        {
            if (!_unitConfigsMap.ContainsKey(unitID))
            {
                unitType = UnitType.Unknown;
                return false;
            }

            unitType = _unitConfigsMap[unitID].Type;
            return true;
        }

        [Serializable]
        private class UnitConfigMap : Map<string, UnitConfig>
        {
            protected override string SelectKey(UnitConfig value) => value.ID;
        }
    }
}
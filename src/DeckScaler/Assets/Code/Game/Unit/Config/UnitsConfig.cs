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

        public UnitConfig this[UnitIDRef id] => _unitConfigsMap[id];

        public IEnumerable<UnitConfig> Leads   => UnitsOfType(UnitType.Lead);
        public IEnumerable<UnitConfig> Allies  => UnitsOfType(UnitType.Ally);
        public IEnumerable<UnitConfig> Enemies => UnitsOfType(UnitType.Enemy);

        private IEnumerable<UnitConfig> UnitsOfType(UnitType unitType)
            => _unitConfigsMap.Values.Where(c => c.Type == unitType);

        public bool ContainsUnit(UnitIDRef unitID)
            => _unitConfigsMap.ContainsKey(unitID);

        public bool TryGet(UnitIDRef unitID, out UnitConfig unitType)
        {
            if (!ContainsUnit(unitID))
            {
                unitType = null;
                return false;
            }

            unitType = _unitConfigsMap[unitID];
            return true;
        }

        [Serializable]
        private class UnitConfigMap : Map<UnitIDRef, UnitConfig>
        {
            protected override UnitIDRef SelectKey(UnitConfig value) => value.ID;
        }
    }
}
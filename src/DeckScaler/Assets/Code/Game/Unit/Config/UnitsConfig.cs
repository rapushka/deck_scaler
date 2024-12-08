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

        [Header("Unit Types")]
        [SerializeField] private UnitIDRef[] _enemies;
        [SerializeField] private UnitIDRef[] _teammates;
        [NaughtyAttributes.InfoBox("All Allies are also Teammates")]
        [SerializeField] private UnitIDRef[] _allies;
        [NaughtyAttributes.InfoBox("All Leads are also Allies")]
        [SerializeField] private UnitIDRef[] _leads;

        [field: SerializeField] public float           DelayBetweenAttacks { get; private set; }
        [field: SerializeField] public EntityBehaviour ViewPrefab          { get; private set; }

        public UnitConfig this[UnitIDRef id] => GetConfig(id);

        public IEnumerable<UnitConfig> Teammates => _teammates.Select(GetConfig);
        public IEnumerable<UnitConfig> Allies    => _allies.Select(GetConfig);
        public IEnumerable<UnitConfig> Leads     => _leads.Select(GetConfig);
        public IEnumerable<UnitConfig> Enemies   => _enemies.Select(GetConfig);

        private IEnumerable<UnitConfig> UnitsOfType(UnitType unitType)
            => _unitConfigsMap.Values.Where(c => c.Type == unitType);

        public UnitConfig GetConfig(UnitIDRef id) => _unitConfigsMap[id];

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
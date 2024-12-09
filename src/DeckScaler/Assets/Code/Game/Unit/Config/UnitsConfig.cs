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
        [SerializeField] private UnitIDRef[] _leads;
        [SerializeField] private UnitIDRef[] _allies;
        [SerializeField] private UnitIDRef[] _enemies;

        [field: SerializeField] public float           DelayBetweenAttacks { get; private set; }
        [field: SerializeField] public EntityBehaviour ViewPrefab          { get; private set; }

        public UnitConfig this[UnitIDRef id] => GetConfig(id);

        public IEnumerable<UnitConfig> Allies  => _allies.Select(GetConfig);
        public IEnumerable<UnitConfig> Leads   => _leads.Select(GetConfig);
        public IEnumerable<UnitConfig> Enemies => _enemies.Select(GetConfig);

        public UnitConfig GetConfig(UnitIDRef id) => _unitConfigsMap[id];

        public bool ContainsUnit(UnitIDRef unitID)
            => _unitConfigsMap.ContainsKey(unitID);

        public bool TryGet(UnitIDRef unitID, out UnitConfig unitType)
            => _unitConfigsMap.TryGet(unitID, out unitType);

        [Serializable]
        private class UnitConfigMap : Map<UnitIDRef, UnitConfig>
        {
            protected override UnitIDRef SelectKey(UnitConfig value) => value.ID;
        }
    }
}
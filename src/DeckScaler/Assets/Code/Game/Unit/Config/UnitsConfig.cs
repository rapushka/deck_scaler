using System;
using System.Collections.Generic;
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

        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        public UnitConfig this[UnitIDRef id] => GetConfig(id);

        public IEnumerable<UnitIDRef> Allies  => _allies;
        public IEnumerable<UnitIDRef> Leads   => _leads;
        public IEnumerable<UnitIDRef> Enemies => _enemies;

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
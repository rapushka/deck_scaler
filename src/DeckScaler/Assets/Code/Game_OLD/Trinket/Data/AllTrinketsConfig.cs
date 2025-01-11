using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AllTrinketsConfig
    {
        [SerializeField] private TrinketsMap _trinkets;

        [field: SerializeField] public EntityBehaviour ViewPrefab     { get; private set; }
        [field: SerializeField] public EntityBehaviour SlotViewPrefab { get; private set; }

        [field: SerializeField] public float   SlotsSpacing { get; private set; }
        [field: SerializeField] public Vector2 RootPosition { get; private set; }

        [field: Header("Usage")]
        [field: SerializeField] public float DroppedTrinketUseRange { get; private set; }

        public TrinketConfig GetConfig(TrinketIDRef id) => _trinkets[id];

        public IReadOnlyCollection<TrinketIDRef> TrinketIDs => _trinkets.Keys;

        [Serializable]
        private class TrinketsMap : Map<TrinketIDRef, TrinketConfig>
        {
            protected override TrinketIDRef SelectKey(TrinketConfig config) => config.ID;
        }
    }
}
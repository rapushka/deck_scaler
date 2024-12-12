using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AllTrinketsConfig
    {
        [SerializeField] private TrinketsMap _trinkets;

        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        public TrinketConfig GetConfig(TrinketIDRef id) => _trinkets[id];

        [Serializable]
        private class TrinketsMap : Map<TrinketIDRef, TrinketConfig>
        {
            protected override TrinketIDRef SelectKey(TrinketConfig config) => config.ID;
        }
    }
}
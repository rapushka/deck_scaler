using System;
using DeckScaler.Utils;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitsConfig))]
    public class UnitsConfig : ScriptableObject
    {
        [field: SerializeField] public EntityBehaviour UnitViewPrefab { get; private set; }

        [field: SerializeField] public SerializableDictionary<string, UnitConfig> UnitConfigs { get; private set; }

        [field: SerializeField] public SerializableDictionary<Suit, Sprite> CardBackgrounds { get; private set; }

        [Serializable]
        public class UnitConfig
        {
            [field: SerializeField] public Sprite Portrait { get; private set; }
            [field: SerializeField] public int    Health   { get; private set; }
            [field: SerializeField] public Suit   Suit     { get; private set; }
            [field: SerializeField] public StatsData  StatsData    { get; private set; }
        }
    }
}
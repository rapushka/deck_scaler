using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class TeamSlotViewConfig
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        [field: SerializeField] public float SpacingBetweenSlots { get; private set; }
    }
}
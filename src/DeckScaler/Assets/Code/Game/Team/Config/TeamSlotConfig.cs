using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class TeamSlotConfig
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }
    }
}
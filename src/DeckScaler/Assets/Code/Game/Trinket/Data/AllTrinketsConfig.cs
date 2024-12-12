using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class AllTrinketsConfig
    {
        [field: SerializeField] public TrinketConfig[] Trinkets { get; private set; }
    }
}
using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class MapConfig
    {
        [field: SerializeField] public int   CountOfLevelOnStreet { get; private set; }
        [field: SerializeField] public float DelayBeforeMapAppear { get; private set; }
    }
}
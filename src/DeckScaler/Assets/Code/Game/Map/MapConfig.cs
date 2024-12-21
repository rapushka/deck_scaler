using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class MapConfig
    {
        [field: SerializeField] public int CountOfStagesOnStreet { get; private set; }

        [field: SerializeField] public int CountOfStreets { get; private set; }

        [field: SerializeField] public float DelayBeforeMapAppear { get; private set; }
    }
}
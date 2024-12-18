using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DeckScaler
{
    [Serializable]
    public class MapConfig
    {
        [field: FormerlySerializedAs("CountOfLevelOnStreet")] // TODO: REMOVE ME
        [field: SerializeField] public int CountOfStagesOnStreet { get; private set; }

        [field: SerializeField] public int CountOfStreets { get; private set; }

        [field: SerializeField] public float DelayBeforeMapAppear { get; private set; }
    }
}
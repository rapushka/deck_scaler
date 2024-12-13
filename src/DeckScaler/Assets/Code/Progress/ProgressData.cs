using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ProgressData
    {
        [field: SerializeField] public List<UnitIDRef> TeammateIDs { get; private set; }
        [field: SerializeField] public int             Gold        { get; private set; }
        [field: SerializeField] public int             EnemyGold   { get; private set; }

        [field: SerializeField] public List<TrinketIDRef> Trinkets         { get; private set; }
        [field: SerializeField] public int                TrinketSlotCount { get; private set; }

        [field: HideInInspector]
        [field: SerializeField] public int CurrentLevelIndex { get; private set; }

        [field: HideInInspector]
        [field: SerializeField] public int CurrentStreetIndex { get; private set; }

        public static ProgressData NewRun(ProgressData from)
            => new()
            {
                TeammateIDs = from.TeammateIDs,
                Gold = from.Gold,
                EnemyGold = from.EnemyGold,
                CurrentLevelIndex = 0,
                CurrentStreetIndex = 0,
                Trinkets = from.Trinkets,
                TrinketSlotCount = from.TrinketSlotCount,
            };

        public void MarkLevelAsCompleted()
        {
            CurrentLevelIndex++;
        }

        public void GoToNextStreet()
        {
            CurrentLevelIndex = 0;
            CurrentStreetIndex++;
        }
    }
}
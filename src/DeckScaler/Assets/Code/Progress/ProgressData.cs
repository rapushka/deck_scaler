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

        [field: HideInInspector]
        [field: SerializeField] public int CurrentLevelIndex { get; private set; }

        public void AddTeammate(string unitID)
        {
            TeammateIDs.Add(unitID);
        }

        public static ProgressData NewRun(ProgressData from)
        {
            return new()
            {
                TeammateIDs = from.TeammateIDs,
                Gold = from.Gold,
                EnemyGold = from.EnemyGold,
                CurrentLevelIndex = 0,
            };
        }

        public void MarkLevelAsCompleted()
        {
            CurrentLevelIndex++;
        }
    }
}
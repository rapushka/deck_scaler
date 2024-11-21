using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ProgressData
    {
        [field: SerializeField] public List<UnitIDRef> TeammateIDs { get; private set; }

        public int TeamSlotsCounter { get; private set; }

        public void AddTeammate(string unitID)
        {
            TeammateIDs.Add(unitID);
        }

        public void IncrementTeamSlotCount()
        {
            TeamSlotsCounter++;
        }

        public static ProgressData NewRun(ProgressData from)
        {
            return new ProgressData
            {
                TeammateIDs = from.TeammateIDs,
            };
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ProgressData
    {
        [field: SerializeField] public List<UnitIDRef> TeammateIDs { get; private set; }

        public FightStep CurrentFightStep { get; set; }

        public void AddTeammate(string unitID)
        {
            TeammateIDs.Add(unitID);
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
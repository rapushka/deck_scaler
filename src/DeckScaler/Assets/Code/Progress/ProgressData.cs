using System;
using DeckScaler.Utils;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ProgressData
    {
        [field: IdRef(startsWith: Constants.TableID.Units)]
        [field: SerializeField] public string SelectedLeadID { get; private set; }

        [field: HideInInspector]
        [field: SerializeField] public int Stage { get; private set; }

        public void SelectLead(string leadID)
        {
            SelectedLeadID = leadID;
        }
    }
}
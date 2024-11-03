using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class ProgressData
    {
        [field: SerializeField] public string SelectedLeadID { get; private set; }
        [field: SerializeField] public int    Stage          { get; private set; }

        public void SelectLead(string leadID)
        {
            SelectedLeadID = leadID;
        }
    }
}
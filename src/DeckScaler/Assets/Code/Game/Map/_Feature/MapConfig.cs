using System;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class MapConfig
    {
        [field: SerializeField] public int CountOfStagesOnStreet { get; private set; }

        [field: SerializeField] public int CountOfStreets { get; private set; }

        [field: SerializeField] public float DelayBeforeMapAppear { get; private set; }

        [field: Header("Stages Configs")]
        [field: SerializeField] public SerializedDictionary<int, StageType> SpecialStageIndexes { get; private set; }

        [field: SerializeField] public int CountOfRecruitmentCandidates { get; private set; }
    }
}
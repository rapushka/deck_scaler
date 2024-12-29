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

        [field: SerializeField] public RecruitmentStageConfig Recruitment { get; private set; }
        [field: SerializeField] public ShopStageConfig        Shop        { get; private set; }

        [Serializable]
        public struct RecruitmentStageConfig
        {
            [field: SerializeField] public int RecruitCount { get; private set; }
        }

        [Serializable]
        public struct ShopStageConfig
        {
            [field: SerializeField] public int UnitCount    { get; private set; }
            [field: SerializeField] public int TrinketCount { get; private set; }
        }
    }
}
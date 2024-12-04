using System;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class TeamSlotViewConfig
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        [field: SerializeField] public float SpacingBetweenSlots { get; private set; }

        [field: SerializeField] public SerializedDictionary<Side, Vector2> SlotOffsetsBySide { get; private set; }

        [field: SerializeField] public StretchyScrollParams StretchyScroll { get; private set; }

        [field: SerializeField] public float DelayBeforeFillingGaps { get; private set; } = 0.3f;

        [Serializable]
        public struct StretchyScrollParams
        {
            [field: SerializeField] public float DelayAtCenter       { get; private set; }
            [field: SerializeField] public float StepPerDistanceRate { get; private set; }
        }
    }
}
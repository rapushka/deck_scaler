using System;
using UnityEngine;

namespace DeckScaler
{
    [Serializable]
    public class TeamSlotViewConfig
    {
        [field: SerializeField] public EntityBehaviour ViewPrefab { get; private set; }

        [field: SerializeField] public float SpacingBetweenSlots { get; private set; }

        [field: SerializeField] public Vector2 TeammateInSlotOffset { get; private set; }
        [field: SerializeField] public Vector2 EnemyInSlotOffset    { get; private set; }

        [field: Space]
        [field: SerializeField] public float StretchyScrollStartingDelay { get; private set; } = 0.1f;

        [field: SerializeField] public float StretchyScrollDelayStep { get; private set; } = 0.1f;
        [field: SerializeField] public float StretchyScrollLerp      { get; private set; } = 0.1f;

        [field: Space]
        [field: SerializeField] public float StretchyScrollAdd { get; private set; } = 0.1f;

        [field: SerializeField] public float StretchyScrollMult { get; private set; } = 0.1f;

        [field: SerializeField] public StretchyScrollParams StretchyScroll { get; private set; }

        [Serializable]
        public struct StretchyScrollParams
        {
            [field: SerializeField] public float DelayAtCenter       { get; private set; }
            [field: SerializeField] public float StepPerDistanceRate { get; private set; }
        }
    }
}
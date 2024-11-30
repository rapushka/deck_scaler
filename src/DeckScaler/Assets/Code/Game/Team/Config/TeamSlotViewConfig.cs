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

        [field: SerializeField] public StretchyScrollParams StretchyScroll { get; private set; }

        [Serializable]
        public struct StretchyScrollParams
        {
            [field: SerializeField] public float DelayAtCenter       { get; private set; }
            [field: SerializeField] public float StepPerDistanceRate { get; private set; }
        }
    }
}
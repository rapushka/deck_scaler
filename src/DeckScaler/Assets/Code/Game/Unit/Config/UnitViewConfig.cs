using System;
using UnityEngine;

namespace DeckScaler
{
    [CreateAssetMenu(menuName = Constants.MenuPrefix + nameof(UnitViewConfig))]
    public class UnitViewConfig : ScriptableObject
    {
        private const string Timings = nameof(Timings);

        [field: SerializeField] public Vector2 TeammateSpawnOffset { get; private set; }
        [field: SerializeField] public Vector2 EnemySpawnOffset    { get; private set; }

        [field: SerializeField] public float AppearDuration          { get; private set; }
        [field: SerializeField] public float ReturnAfterDragDuration { get; private set; }

        [field: SerializeField] public SortingOrderIndexes SortingOrder { get; private set; }

        [field: NaughtyAttributes.Foldout(Timings)]
        [field: SerializeField] public float DelayBetweenAttacks { get; private set; } = 0.3f;
        [field: NaughtyAttributes.Foldout(Timings)]
        [field: SerializeField] public float DelayBetweenOnTurnStartAbilities { get; private set; } = 0.1f;

        [Serializable]
        public class SortingOrderIndexes
        {
            public int Idle;
            public int Attack = 1;
            public int PerIndexStep = 1;

            public int Dragging = 10;
        }
    }
}
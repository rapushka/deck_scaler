using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnPlayerPrepareStepPrepareUnitsToMove : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TurnStarted>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _unitsToMove
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<MoveSlotToLeft>()
                    .And<SlotIndex>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _unitsToMove.GetEntities(_buffer))
            {
                var oldSlotIndex = unit.Pop<SlotIndex, int>();
                unit.Add<RetainedSlotIndex, int>(oldSlotIndex);
            }
        }
    }
}
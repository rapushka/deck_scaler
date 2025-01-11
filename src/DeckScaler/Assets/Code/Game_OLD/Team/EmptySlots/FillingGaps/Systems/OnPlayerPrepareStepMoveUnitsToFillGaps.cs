using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class OnPlayerPrepareStepMoveUnitsToFillGaps : IExecuteSystem
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
                    .And<RetainedSlotIndex>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var unit in _unitsToMove.GetEntities(_buffer))
            {
                var delta = unit.Pop<MoveSlotToLeft, int>();
                var oldIndex = unit.Pop<RetainedSlotIndex, int>();

                unit
                    .Add<SlotIndex, int>(oldIndex - delta)
                    .Add<ReturnToSlot>()
                    ;
            }
        }
    }
}
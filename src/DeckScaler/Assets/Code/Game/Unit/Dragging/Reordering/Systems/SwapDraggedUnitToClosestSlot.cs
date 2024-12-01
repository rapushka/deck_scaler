using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SwapDraggedUnitToClosestSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _draggedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .And<UnitID>()
                    .And<InSlot>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .And<ClosestSlotForReorder>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var slot in _slots)
            foreach (var unit in _draggedUnits)
            {
                var previousSlotID = unit.Get<InSlot, EntityID>();
                var newSlotID = slot.Get<ID, EntityID>();

                if (previousSlotID == newSlotID)
                    continue;

                if (slot.TryGet<HeldTeammate, EntityID>(out var teammateID))
                {
                    teammateID.GetEntity()
                        .Replace<InSlot, EntityID>(previousSlotID)
                        .Add<ReturnToSlot>()
                        ;
                }

                unit
                    .Replace<InSlot, EntityID>(newSlotID)
                    ;
            }
        }
    }
}
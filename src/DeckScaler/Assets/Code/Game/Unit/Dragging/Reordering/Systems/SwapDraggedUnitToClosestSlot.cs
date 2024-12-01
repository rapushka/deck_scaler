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
            foreach (var newSlot in _slots)
            foreach (var unit in _draggedUnits)
            {
                var oldSlotID = unit.Get<InSlot, EntityID>();
                var newSlotID = newSlot.Get<ID, EntityID>();

                if (oldSlotID == newSlotID)
                    continue;

                if (newSlot.TryGet<HeldTeammate, EntityID>(out var teammateID))
                {
                    teammateID.GetEntity()
                        .SetupTeammateToSlot(oldSlotID.GetEntity())
                        .Add<ReturnToSlot>();
                }

                unit.SetupTeammateToSlot(newSlot);
            }
        }
    }
}
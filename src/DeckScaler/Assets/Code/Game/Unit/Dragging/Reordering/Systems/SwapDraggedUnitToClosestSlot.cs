using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    // public sealed class SwapDraggedUnitToClosestSlot : IExecuteSystem
    // {
    //     private readonly IGroup<Entity<Game>> _draggedUnits
    //         = Contexts.Instance.GetGroup(
    //             MatcherBuilder<Game>
    //                 .With<Dragging>()
    //                 .And<UnitID>()
    //                 .And<SlotIndex>()
    //                 .Build()
    //         );
    //     private readonly IGroup<Entity<Game>> _placedUnits
    //         = Contexts.Instance.GetGroup(
    //             MatcherBuilder<Game>
    //                 .With<SlotIndex>()
    //                 .And<ClosestSlotForReorder>()
    //                 .Build()
    //         );
    //
    //     public void Execute()
    //     {
    //         foreach (var closestUnit in _placedUnits)
    //         foreach (var draggedUnit in _draggedUnits)
    //         {
    //             var oldSlotIndex = draggedUnit.Get<SlotIndex, int>();
    //             var newSlotIndex = closestUnit.Get<SlotIndex, int>();
    //
    //             if (oldSlotIndex == newSlotIndex)
    //                 continue;
    //
    //             if (closestUnit.TryGet<HeldTeammate, EntityID>(out var teammateID))
    //             {
    //                 teammateID.GetEntity()
    //                     .SetupTeammateToSlot(oldSlotIndex.GetEntity())
    //                     .Add<ReturnToSlot>();
    //             }
    //
    //             draggedUnit.SetupTeammateToSlot(closestUnit);
    //         }
    //     }
    // }
}
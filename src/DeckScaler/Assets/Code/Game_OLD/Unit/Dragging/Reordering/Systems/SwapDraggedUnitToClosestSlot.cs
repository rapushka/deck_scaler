using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SwapDraggedUnitToClosestSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _draggedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .And<Unit>()
                    .And<SlotIndex>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _unitsToSwap
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SlotIndex>()
                    .And<ClosestSlotForReorder>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer1 = new(16);
        private readonly List<Entity<Game>> _buffer2 = new(16);

        public void Execute()
        {
            foreach (var unitToSwap in _unitsToSwap.GetEntities(_buffer1))
            foreach (var draggedUnit in _draggedUnits.GetEntities(_buffer2))
            {
                var oldSlotIndex = draggedUnit.Get<SlotIndex, int>();
                var newSlotIndex = unitToSwap.Get<SlotIndex, int>();

                if (oldSlotIndex == newSlotIndex)
                    continue;

                draggedUnit.SwapValues<SlotIndex, int>(unitToSwap);
                unitToSwap.Add<ReturnToSlot>();
            }
        }
    }
}
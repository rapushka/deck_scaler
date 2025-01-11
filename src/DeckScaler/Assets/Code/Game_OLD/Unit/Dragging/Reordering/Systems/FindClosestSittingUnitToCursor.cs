using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler
{
    public sealed class FindClosestSittingUnitToCursor : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _draggedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .And<Unit>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _placedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<WorldPosition>()
                    .And<Teammate>()
                    .Without<Dragging>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var draggedUnit in _draggedUnits)
            foreach (var cursor in _cursors)
            {
                var cursorPosition = cursor.Get<WorldPosition, Vector2>();
                var initialSlotPosition = draggedUnit.Get<SlotPosition, Vector2>();
                var distanceToInitialPosition = cursorPosition.DistanceTo(initialSlotPosition);

                var closestSlot = _placedUnits.MinByOrDefault<SlotPosition>((s) => cursorPosition.DistanceTo(s.Value));
                if (closestSlot is null)
                    continue;

                var closestPosition = closestSlot.Get<SlotPosition>().Value;
                var distanceToClosestPosition = cursorPosition.DistanceTo(closestPosition);

                if (distanceToInitialPosition > distanceToClosestPosition)
                    closestSlot.Is<ClosestSlotForReorder>(true);
            }
        }
    }
}
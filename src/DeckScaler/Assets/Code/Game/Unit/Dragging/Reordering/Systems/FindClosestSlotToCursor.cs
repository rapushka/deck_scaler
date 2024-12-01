using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Systems
{
    public sealed class FindClosestSlotToCursor : IExecuteSystem
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
                    .And<UnitID>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TeamSlot>()
                    .And<WorldPosition>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _draggedUnits)
            foreach (var cursor in _cursors)
            {
                var cursorPosition = cursor.Get<WorldPosition, Vector2>();

                var closestSlot = _slots.MinByOrDefault<WorldPosition>((s) => cursorPosition.DistanceTo(s.Value));
                closestSlot?.Is<ClosestSlotForReorder>(true);
            }
        }
    }
}
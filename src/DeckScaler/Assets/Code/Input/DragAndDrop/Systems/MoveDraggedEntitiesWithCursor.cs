using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Systems
{
    public sealed class MoveDraggedEntitiesWithCursor : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _draggedEntities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dragging>()
                    .And<WorldPosition>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<Pressed>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var entity in _draggedEntities)
            foreach (var cursor in _cursors)
            {
                var delta = cursor.Get<MoveDelta>().Value;
                entity.Add<Move, Vector2>(delta);
            }
        }
    }
}
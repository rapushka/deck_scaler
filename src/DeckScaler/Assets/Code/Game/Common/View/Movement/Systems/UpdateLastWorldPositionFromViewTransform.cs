using DeckScaler.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class UpdateLastWorldPositionFromViewTransform : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ViewTransform>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var transform = entity.Get<ViewTransform>().Value;
                var worldPosition = transform.position;

                entity.Replace<LastWorldPosition, Vector2>(worldPosition);
            }
        }
    }
}
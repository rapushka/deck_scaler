using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class UpdatePosition : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ViewTransform>()
                    .And<Position>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var z = entity.GetOrDefault<ZOrder, float>();
                var position = entity.Get<Position>().Value.WithZ(z);

                entity.Get<ViewTransform>().Value.localPosition = position;

                entity.Remove<Position>();
            }
        }
    }
}
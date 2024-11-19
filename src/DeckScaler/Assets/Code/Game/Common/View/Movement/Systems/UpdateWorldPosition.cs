using System.Collections.Generic;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Component
{
    public class UpdateWorldPosition : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ViewTransform>()
                    .And<WorldPosition>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var z = entity.GetOrDefault<ZOrder, float>();
                var position = entity.Get<WorldPosition>().Value.WithZ(z);

                entity.Get<ViewTransform>().Value.position = position;

                entity.Remove<WorldPosition>();
            }
        }
    }
}
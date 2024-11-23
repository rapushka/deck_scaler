using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Utils;
using DG.Tweening;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class UpdateTargetPosition : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ViewTransform>()
                    .And<TargetPosition>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var z = entity.GetOrDefault<ZOrder, float>();

                var transform = entity.Get<ViewTransform>().Value;
                var targetPosition = entity.Get<TargetPosition>().Value;

                transform.DOMove(targetPosition.Extend(z), duration: 0.3f); // TODO: duration

                entity.Remove<TargetPosition>();
            }
        }
    }
}
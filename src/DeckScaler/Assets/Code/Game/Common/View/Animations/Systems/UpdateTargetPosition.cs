using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Utils;
using DG.Tweening;
using Entitas;
using Entitas.Generic;
using UnityEngine;

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
                var duration = entity.GetOrDefault<AnimationDuration, float>(Constants.Animation.DefaultDuration);
                var z = entity.GetOrDefault<ZOrder, float>();
                var easing = entity.GetOrDefault<Easing, AnimationCurve>(Constants.Animation.LinearEasing);

                var transform = entity.Get<ViewTransform>().Value;
                var targetPosition = entity.Get<TargetPosition>().Value;

                transform.DOLocalMove(targetPosition.Extend(z), duration)
                         .SetEase(easing)
                    ;

                entity.Remove<TargetPosition>();
            }
        }
    }
}
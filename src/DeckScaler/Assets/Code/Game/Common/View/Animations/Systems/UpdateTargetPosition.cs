using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Utils;
using DG.Tweening;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class UpdateTargetPosition : IExecuteSystem
    {
        private static readonly AnimationCurve LinearEasing = AnimationCurve.Linear(0f, 0f, 1f, 1f);

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
                var easing = entity.GetOrDefault<Easing, AnimationCurve>(LinearEasing);

                var transform = entity.Get<ViewTransform>().Value;
                var targetPosition = entity.Get<TargetPosition>().Value;

                transform.DOMove(targetPosition.Extend(z), duration: 0.3f) // TODO: duration
                         .SetEase(easing)
                    ;

                entity.Remove<TargetPosition>();
            }
        }
    }
}
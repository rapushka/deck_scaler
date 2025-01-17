using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
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
                    .And<WorldPosition>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var currentPosition = entity.Get<WorldPosition, Vector2>();
                var targetPosition = entity.Get<TargetPosition>().Value;

                if (!currentPosition.ApproximatelyEquals(targetPosition))
                    MoveToTargetWithTween(entity);

                entity.Remove<TargetPosition>();
            }
        }

        private static void MoveToTargetWithTween(Entity<Game> entity)
        {
            if (entity.TryGet<PlayingAnimation, Tween>(out var oldTween))
                oldTween?.Kill();

            var duration = entity.GetOrDefault<AnimationDuration, float>(Constants.Animation.DefaultDuration);
            var easing = entity.GetOrDefault<Easing, AnimationCurve>(Constants.Animation.LinearEasing);

            var targetPosition = entity.Get<TargetPosition>().Value;

            var tween = DOTween.To(
                    getter: entity.Get<WorldPosition, Vector2>,
                    setter: (v) => entity.Replace<WorldPosition, Vector2>(v),
                    endValue: targetPosition,
                    duration: duration
                )
                .SetEase(easing);

            entity.Replace<PlayingAnimation, Tween>(tween);
        }
    }
}
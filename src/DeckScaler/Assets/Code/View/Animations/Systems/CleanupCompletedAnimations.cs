using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DG.Tweening;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class CleanupCompletedAnimations : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<PlayingAnimation>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var tween = entity.Get<PlayingAnimation>().Value;
                if (!tween.IsActive() || tween.IsComplete())
                {
                    entity
                        .Remove<PlayingAnimation>()
                        ;
                }
            }
        }
    }
}
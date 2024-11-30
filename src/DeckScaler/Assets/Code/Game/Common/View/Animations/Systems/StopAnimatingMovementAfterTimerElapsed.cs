using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class StopAnimatingMovementAfterTimerElapsed : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StopAnimatingMovementAfter>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.Get<StopAnimatingMovementAfter, Timer>().IsElapsed)
                    entity.Is<AnimateMovement>(false);
            }
        }
    }
}
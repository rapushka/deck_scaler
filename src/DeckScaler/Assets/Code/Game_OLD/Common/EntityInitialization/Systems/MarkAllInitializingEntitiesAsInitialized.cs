using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class MarkAllInitializingEntitiesAsInitialized : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Initializing>()
                    .Build()
            );

        private readonly List<Entity<Game>> _buffer = new(128);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                entity
                    .Is<Initializing>(false)
                    .Is<Initialized>(true)
                    ;
            }
        }
    }
}
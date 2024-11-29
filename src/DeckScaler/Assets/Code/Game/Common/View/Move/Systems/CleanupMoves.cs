using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class CleanupMoves : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Move>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new();

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Remove<Move>();
        }
    }
}
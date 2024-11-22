using System.Collections.Generic;
using DeckScaler.Component;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class CleanupAttackers : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _attackers = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Attack>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Cleanup()
        {
            foreach (var entity in _attackers.GetEntities(_buffer))
                entity.Remove<Attack>();
        }
    }
}
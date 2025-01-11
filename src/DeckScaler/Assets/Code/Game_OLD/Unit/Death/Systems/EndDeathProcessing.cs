using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class EndDeathProcessing : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<JustDied>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Is<JustDied>(false);
        }
    }
}
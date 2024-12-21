using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class MarkLevelCompletedEventProcessed : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<LevelCompleted>()
                    .Without<Processed>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        public void Execute()
        {
            foreach (var entity in _events.GetEntities(_buffer))
                entity.Is<Processed>(true);
        }
    }
}
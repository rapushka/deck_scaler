using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class MoveWorldPosition : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Move>()
                    .And<WorldPosition>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var entity in _entities)
                entity.Increment<WorldPosition>(entity.Get<Move>());
        }
    }
}
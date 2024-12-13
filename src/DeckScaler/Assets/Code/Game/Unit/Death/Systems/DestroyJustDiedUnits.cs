using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class DestroyJustDiedUnits : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<JustDied>()
                    .And<Unit>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var entity in _entities)
                entity.Add<Destroy>();
        }
    }
}
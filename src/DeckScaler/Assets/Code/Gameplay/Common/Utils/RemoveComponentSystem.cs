using System.Collections.Generic;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RemoveComponentSystem<TComponent> : ICleanupSystem
        where TComponent : IComponent, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TComponent>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Remove<TComponent>();
        }
    }
}
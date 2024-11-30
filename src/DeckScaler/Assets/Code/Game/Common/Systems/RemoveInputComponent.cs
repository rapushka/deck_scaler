using System.Collections.Generic;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class RemoveInputComponent<TComponent> : ICleanupSystem
        where TComponent : IComponent, IInScope<Input>, new()
    {
        private readonly IGroup<Entity<Input>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<TComponent>()
                    .Build()
            );
        private readonly List<Entity<Input>> _buffer = new(32);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Remove<TComponent>();
        }
    }
}
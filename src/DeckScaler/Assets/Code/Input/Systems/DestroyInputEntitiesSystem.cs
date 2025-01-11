using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class DestroyInputEntitiesSystem : ICleanupSystem
    {
        private readonly IGroup<Entity<Input>> _entities = Contexts.Instance.GetGroup(
            MatcherBuilder<Input>
                .With<Destroy>()
                .Build()
        );
        private readonly List<Entity<Input>> _buffer = new(64);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
                entity.Destroy();
        }
    }
}
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class DestroyEntitiesAfterDelay : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<DestroyAfterDelay>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.Get<DestroyAfterDelay>().Value.IsElapsed)
                    entity.Is<Destroy>(true);
            }
        }
    }
}
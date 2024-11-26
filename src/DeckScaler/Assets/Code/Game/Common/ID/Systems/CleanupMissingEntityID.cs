using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class CleanupMissingEntityID<TComponent> : ICleanupSystem
        where TComponent : ValueComponent<EntityID>, IInScope<Game>, new()
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TComponent>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(64);

        private static PrimaryEntityIndex<Game, ID, EntityID> Index => Contexts.Instance.EntityIDIndex();

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (Index.HasEntity(entity.Get<TComponent>().Value))
                    entity.Remove<TComponent>();
            }
        }
    }
}
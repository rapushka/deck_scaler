using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class DestroyEntityBehaviours : ICleanupSystem
    {
        private readonly IGroup<Entity<Game>> _entities = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Destroy>()
                .And<View>()
                .Build()
        );
        private readonly List<Entity<Game>> _buffer = new(64);

        public void Cleanup()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var view = entity.Get<View>().Value;
                view.Unregister();

                view.DestroyObject();
            }
        }
    }
}
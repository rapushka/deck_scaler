using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SetParentForViewTransform : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ParentTransform>()
                    .And<ViewTransform>()
                    .Build()
            );

        private readonly List<Entity<Game>> _buffer = new(64);

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                var changePosition = entity.Is<ForceChangePositionOnReparent>();

                var parent = entity.Get<ParentTransform>().Value;
                entity.Get<ViewTransform>().Value.SetParent(parent, worldPositionStays: !changePosition);

                entity.Remove<ParentTransform>()
                      .RemoveSafely<ForceChangePositionOnReparent>()
                    ;
            }
        }
    }
}
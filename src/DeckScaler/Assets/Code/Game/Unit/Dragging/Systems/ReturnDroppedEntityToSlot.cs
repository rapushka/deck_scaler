using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class ReturnDroppedEntityToSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _droppedEntity
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Dropped>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var unit in _droppedEntity)
                unit.Is<ReturnToSlot>(true);
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class SendRecalculateOpponentsOnUnitDropped : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _droppedUnits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Unit>()
                    .And<Dropped>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _droppedUnits)
                CreateEntity.OneFrame().Add<RecalculateOpponents>();
        }
    }
}
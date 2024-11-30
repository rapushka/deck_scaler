using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SetIdleUnitSortingLayer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SortingOrder>()
                    .Without<PlayingAnimation>()
                    .Without<TargetPosition>()
                    .Without<Dragging>()
                    .Build()
            );

        private static UnitViewConfig.SortingOrderIndexes Config => Services.Get<IConfigs>().UnitView.SortingOrder;

        public void Execute()
        {
            foreach (var unit in _units)
                unit.ReplaceIfDifferent<SortingOrder, int>(Config.Idle);
        }
    }
}
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
                    .With<Unit>()
                    .And<SpriteSortOrder>()
                    .Without<PlayingAnimation>()
                    .Without<TargetPosition>()
                    .Without<Dragging>()
                    .Build()
            );

        private static UnitViewConfig.SortingOrderIndexes Config => ServiceLocator.Resolve<IConfigs>().UnitView.SortingOrder;

        public void Execute()
        {
            foreach (var unit in _units)
                unit.ReplaceIfDifferent<SpriteSortOrder, int>(Config.Idle);
        }
    }
}
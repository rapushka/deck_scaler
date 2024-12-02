using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SetDraggingUnitSortingLayer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SpriteSortOrder>()
                    .And<Dragging>()
                    .Without<PlayingAttackAnimation>()
                    .Without<TargetPosition>()
                    .Build()
            );

        private static UnitViewConfig.SortingOrderIndexes Config => Services.Get<IConfigs>().UnitView.SortingOrder;

        public void Execute()
        {
            foreach (var unit in _units)
                unit.ReplaceIfDifferent<SpriteSortOrder, int>(Config.Dragging);
        }
    }
}
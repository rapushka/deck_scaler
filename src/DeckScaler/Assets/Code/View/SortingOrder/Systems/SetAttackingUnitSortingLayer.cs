using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SetAttackingUnitSortingLayer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SpriteSortOrder>()
                    .And<PlayingAttackAnimation>()
                    .Without<Dragging>()
                    .Build()
            );

        private static UnitViewConfig.SortingOrderIndexes Config => ServiceLocator.Get<IConfigs>().UnitView.SortingOrder;

        public void Execute()
        {
            foreach (var unit in _units)
            {
                var slotIndex = unit.Get<SlotIndex, int>();
                unit.ReplaceIfDifferent<SpriteSortOrder, int>(Config.Attack + slotIndex);
            }
        }
    }
}
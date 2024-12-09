using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class ArrangeTeamSlots : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _roots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamRoot>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _units
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UnitID>()
                    .And<SlotIndex>()
                    .And<OnSide>()
                    .Build()
            );

        private static TeamSlotViewConfig ViewConfig => ServiceLocator.Resolve<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var root in _roots)
            foreach (var unit in _units)
            {
                var rootPosition = root.Get<WorldPosition, Vector2>();

                var index = unit.Get<SlotIndex, int>() - 1;
                var xPosition = index * ViewConfig.SpacingBetweenSlots;
                var slotCenterPosition = Vector2.right * xPosition;

                var sideOffset = ViewConfig.SlotOffsetsBySide[unit.Get<OnSide, Side>()];

                var prevPosition = unit.GetOrDefault<SlotPosition>();
                var newPosition = slotCenterPosition + rootPosition + sideOffset;

                if (prevPosition is null || !prevPosition.Value.ApproximatelyEquals(newPosition))
                    unit.Replace<SlotPosition, Vector2>(newPosition);
            }
        }
    }
}
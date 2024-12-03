using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler;
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

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        private static TeamSlotsUtil TeamSlotsUtil => Services.Get<IUtils>().TeamSlotsUtil;

        public void Execute()
        {
            foreach (var root in _roots)
            foreach (var (slot, index) in TeamSlotsUtil.GetTeamSlotsInOrder())
            {
                var rootPosition = root.Get<WorldPosition, Vector2>();

                var xPosition = index * ViewConfig.SpacingBetweenSlots;
                var localPosition = Vector2.right * xPosition;

                var targetPosition = localPosition + rootPosition;
                var currentPosition = slot.Get<WorldPosition, Vector2>();

                if (!currentPosition.ApproximatelyEquals(targetPosition))
                    slot.SetPositionAnimatable(targetPosition);
            }
        }
    }
}
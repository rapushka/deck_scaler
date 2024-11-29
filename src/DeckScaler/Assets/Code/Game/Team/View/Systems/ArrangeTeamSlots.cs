using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public class ArrangeTeamSlots : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _event = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<Component.ArrangeTeamSlots>()
                .Build()
        );

        private readonly IGroup<Entity<Game>> _slots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private static TeamSlotViewConfig ViewConfig => Services.Get<IConfigs>().TeamSlotView;

        public void Execute()
        {
            foreach (var _ in _event)
            foreach (var (slot, index) in _slots.GetTeamSlotsInOrder())
            {
                var xPosition = index * ViewConfig.SpacingBetweenSlots;
                slot.Replace<TargetPosition, Vector2>(Vector2.right * xPosition);
            }
        }
    }
}
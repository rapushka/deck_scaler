using DeckScaler.Component;
using DeckScaler.Service;
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

        private static TeamSlotViewConfig Config => Services.Get<IConfigs>().TeamSlotView;

        private static PrimaryEntityIndex<Game, TeamSlot, int> Index => Contexts.Instance.TeamSlotIndex();

        public void Execute()
        {
            if (!_event.Any())
                return;

            var spacing = Config.SpacingBetweenSlots;
            var slotCount = _slots.count;

            for (var index = 0; index < slotCount; index++)
            {
                var slot = Index.GetEntity(index);

                var xPosition = index * spacing;
                slot.Replace<TargetPosition, Vector2>(Vector2.right * xPosition);
            }
        }
    }
}
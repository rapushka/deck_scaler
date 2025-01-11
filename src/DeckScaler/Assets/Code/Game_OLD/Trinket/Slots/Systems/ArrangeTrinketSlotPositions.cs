using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class ArrangeTrinketSlotPositions : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RearrangeTrinketSlots>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _slots
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TrinketSlot>()
                    .Build()
            );
        private static AllTrinketsConfig ViewConfig => ServiceLocator.Resolve<IConfigs>().Trinkets;

        public void Execute()
        {
            foreach (var _ in _requests)
            foreach (var slot in _slots)
            {
                var rootPosition = ViewConfig.RootPosition;

                var slotIndex = slot.Get<TrinketSlot, int>();
                var xPosition = slotIndex * ViewConfig.SlotsSpacing;
                var slotPosition = Vector2.right * xPosition;

                var newPosition = rootPosition + slotPosition;

                slot.ReplaceIfDifferent<WorldPosition, Vector2>(newPosition);
            }
        }
    }
}
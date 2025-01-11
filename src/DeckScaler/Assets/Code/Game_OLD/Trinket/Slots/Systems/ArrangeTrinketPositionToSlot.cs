using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class ArrangeTrinketPositionToSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RearrangeTrinketSlots>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _trinkets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TrinketInSlot>()
                    .Build()
            );

        private static PrimaryEntityIndex<Game, TrinketSlot, int> SlotsIndex
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<TrinketSlot, int>();

        public void Execute()
        {
            foreach (var _ in _requests)
            foreach (var trinket in _trinkets)
            {
                var slotIndex = trinket.Get<TrinketInSlot, int>();
                var slot = SlotsIndex.GetEntity(slotIndex);

                var slotPosition = slot.Get<WorldPosition, Vector2>();
                trinket
                    .Replace<WorldPosition, Vector2>(slotPosition)
                    .Replace<SlotPosition, Vector2>(slotPosition)
                    ;
            }
        }
    }
}
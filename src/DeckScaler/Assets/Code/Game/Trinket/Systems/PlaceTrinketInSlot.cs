using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class PlaceTrinketInSlot : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _notPlacedTrinkets
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Trinket>()
                    .And<PlayerTrinket>()
                    .Without<TrinketInSlot>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new();

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        public void Execute()
        {
            foreach (var trinket in _notPlacedTrinkets.GetEntities(_buffer))
            {
                if (Utils.TryGetFirstFreeSlotIndex(out var slotIndex))
                    trinket.Add<TrinketInSlot, int>(slotIndex);
                else
                    throw new NotImplementedException("No Free Slots. Something went wrong...");
            }
        }
    }
}
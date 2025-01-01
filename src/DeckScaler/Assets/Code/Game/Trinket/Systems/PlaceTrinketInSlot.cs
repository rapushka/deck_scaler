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

        private static PrimaryEntityIndex<Game, TrinketInSlot, int> PlacedTrinketsIndex
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<TrinketInSlot, int>();

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var trinket in _notPlacedTrinkets.GetEntities(_buffer))
            {
                if (!TryPlaceTrinketInFirstFreeSlot(trinket))
                    throw new NotImplementedException("No Free Slots:( idk how to deal with it yet");
            }
        }

        private static bool TryPlaceTrinketInFirstFreeSlot(Entity<Game> trinket)
        {
            var totalSlotCount = Progress.TrinketSlotCount;
            for (var i = 0; i < totalSlotCount; i++)
            {
                if (PlacedTrinketsIndex.HasEntity(i))
                    continue;

                trinket.Add<TrinketInSlot, int>(i);
                return true;
            }

            return false;
        }
    }
}
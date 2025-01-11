using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using DeckScaler.Systems;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class CheckEmptySlotsForTrinkets : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _trinketsToBuy
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TrinketInShop>()
                    .And<TryBuy>()
                    .Without<PurchaseFailed>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(8);

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        public void Execute()
        {
            if (!_trinketsToBuy.Any())
                return;

            var freeSlotCount = Utils.CountFreeSlots();

            foreach (var item in _trinketsToBuy.GetEntities(_buffer))
            {
                var hasFreeSlot = freeSlotCount > 0;
                freeSlotCount--;

                item
                    .Is<Bought>(hasFreeSlot)
                    .Is<NeedEmptySlot>(!hasFreeSlot)
                    .Is<PurchaseFailed>(!hasFreeSlot)
                    ;
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler
{
    public class TrinketsUtil
    {
        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static AllTrinketsConfig Config => ServiceLocator.Resolve<IConfigs>().Trinkets;

        private static PrimaryEntityIndex<Game, TrinketInSlot, int> PlacedTrinketsIndex
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<TrinketInSlot, int>();

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        private IEnumerable<int> FreeSlotIndexes
        {
            get
            {
                for (var i = 0; i < Progress.TrinketSlotCount; i++)
                {
                    if (!PlacedTrinketsIndex.HasEntity(i))
                        yield return i;
                }
            }
        }

        public IEnumerable<TrinketIDRef> GetRandomTrinketID(int count)
        {
            for (var i = 0; i < count; i++)
                yield return Random.PickRandom(Config.TrinketIDs);
        }

        public Entity<Game> Obtain(Entity<Game> trinket)
            => trinket
                // from shop
                .Is<TrinketInShop>(false)
                .Is<ShopItem>(false)

                // add player's trinket components
                .Add<Draggable>()
                .Add<PlayerTrinket>()
                .Bump();

        public bool TryGetFirstFreeSlotIndex(out int index)
        {
            var firstFreeSlotIndex = FreeSlotIndexes.FirstOr(-1);
            index = firstFreeSlotIndex;

            return index != -1;
        }

        public int CountFreeSlots() => FreeSlotIndexes.Count();
    }
}
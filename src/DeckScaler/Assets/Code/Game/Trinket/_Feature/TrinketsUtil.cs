using System.Collections.Generic;
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
    }
}
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SpawnTrinketsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<SelectStage>()
                    .And<TrinketInShopCount>()
            );

        private static ITrinketFactory Factory => ServiceLocator.Resolve<IFactories>().Trinkets;

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                var trinketCount = stage.Get<TrinketInShopCount, int>();

                foreach (var id in Utils.GetRandomTrinketID(trinketCount))
                {
                    Factory.CreateTrinket(id)
                        .Add<TrinketInShop>()
                        .Add<ShopItem>()
                        ;
                }
            }
        }
    }
}
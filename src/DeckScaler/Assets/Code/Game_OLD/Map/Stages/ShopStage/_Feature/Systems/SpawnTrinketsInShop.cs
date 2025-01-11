using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public sealed class SpawnTrinketsInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RestockShop>()
                    .And<TrinketInShopCount>()
            );

        private static ITrinketFactory Factory => ServiceLocator.Resolve<IFactories>().Trinkets;

        private static TrinketsUtil Utils => ServiceLocator.Resolve<IUtils>().Trinket;

        private static ShopStageView ShopView
            => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>().ShopStageView;

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
                        .Replace<WorldPosition, Vector2>(ShopView.OffscreenPosition)
                        ;
                }
            }
        }
    }
}
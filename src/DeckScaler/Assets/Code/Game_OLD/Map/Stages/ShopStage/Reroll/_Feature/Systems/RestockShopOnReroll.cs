using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RestockShopOnReroll : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RequestReroll>()
            );
        private readonly IGroup<Entity<Game>> _shops
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<CurrentStage>()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var shop in _shops)
            {
                shop.Add<RestockShop>();
            }
        }
    }
}
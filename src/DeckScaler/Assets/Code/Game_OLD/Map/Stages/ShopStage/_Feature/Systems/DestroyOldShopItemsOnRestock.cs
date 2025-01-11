using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class DestroyOldShopItemsOnRestock : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RestockShop>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _items
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopItem>()
                    .Without<Component.RerollButton>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var item in _items)
            {
                item.Add<Destroy>();
            }
        }
    }
}
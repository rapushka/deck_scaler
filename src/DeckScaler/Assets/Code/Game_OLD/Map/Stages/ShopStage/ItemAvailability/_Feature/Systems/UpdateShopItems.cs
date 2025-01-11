using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class UpdateShopItems : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<UpdateShopItemsEvent>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _shopItems
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopItem>()
                    .And<Price>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _playerInventories
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<PlayerInventory>()
                    .And<Money>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _events)
            foreach (var item in _shopItems)
            foreach (var inventory in _playerInventories)
            {
                var currentMoney = inventory.Get<Money, int>();
                var neededMoney = item.Get<Price, int>();

                var hasEnoughMoney = currentMoney.IsEnough(neededMoney);

                item.Is<Interactable>(hasEnoughMoney);
            }
        }
    }
}
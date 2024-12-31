using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Systems;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class TryProcessPurchase : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _products
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<TryBuy>()
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
            foreach (var product in _products)
            foreach (var inventory in _playerInventories)
            {
                var currentMoney = inventory.Get<Money, int>();
                var neededMoney = product.Get<Price, int>();

                var hasEnoughMoney = currentMoney.IsEnough(neededMoney);

                if (hasEnoughMoney)
                    inventory.Increment<Money>(-neededMoney);

                product
                    .Is<Bought>(hasEnoughMoney)
                    .Is<NotEnoughMoney>(!hasEnoughMoney)
                    ;
            }
        }
    }
}
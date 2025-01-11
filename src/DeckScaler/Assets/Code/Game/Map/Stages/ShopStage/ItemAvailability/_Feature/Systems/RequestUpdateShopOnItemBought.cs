using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class RequestUpdateShopOnItemBought : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _boughtItems
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopItem>()
                    .And<Bought>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _boughtItems)
            {
                CreateEntity.OneFrame()
                    .Add<UpdateShopItemsEvent>()
                    ;
            }
        }
    }
}
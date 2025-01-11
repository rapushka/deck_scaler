using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class RequestUpdateShopOnShopEnter : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<SelectStage>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var _ in _stages)
            {
                CreateEntity.OneFrame()
                    .Add<UpdateShopItemsEvent>()
                    ;
            }
        }
    }
}
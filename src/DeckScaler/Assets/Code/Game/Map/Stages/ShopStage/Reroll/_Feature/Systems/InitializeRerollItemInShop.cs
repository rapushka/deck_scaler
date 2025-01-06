using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class InitializeRerollItemInShop : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<ShopStage>()
                    .And<SelectStage>()
            );

        private static ShopStageView ShopView
            => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>().ShopStageView;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                var initialPrice = stage.Get<ShopRerollInitialPrice, int>();

                CreateEntity.Empty()
                    .Add<ShopItem>()
                    .Add<Price, int>(initialPrice)
                    ;
            }
        }
    }
}
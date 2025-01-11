using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SetupShopRerollButton : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<Initializing>()
                    .And<ShopStage>()
                    .Build()
            );

        private static ShopStageView ShopView
            => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>().ShopStageView;

        private static IEntityBehaviourFactory Factory => ServiceLocator.Resolve<IFactories>().EntityBehaviour;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                Factory.Register(ShopView.RerollButton)
                    .Add<Price, int>(stage.Get<ShopRerollInitialPrice, int>())
                    .Add<Interactable>()
                    .Add<Visible>()
                    ;
            }
        }
    }
}
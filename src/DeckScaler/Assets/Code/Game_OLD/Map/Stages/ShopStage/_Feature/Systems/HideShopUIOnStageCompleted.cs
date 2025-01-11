using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class HideShopUIOnStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var _ in _events)
                HUD.ShopStageView.SetActive(false);
        }
    }
}
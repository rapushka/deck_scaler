using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OpenMapAfterDelay : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<OpenMapAfter>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var @event in _events)
            {
                if (!@event.IsElapsed<OpenMapAfter>())
                    continue;

                if (@event.Is<RefreshMap>())
                    HUD.MapView.LoadCurrentStreet();

                HUD.MapView.Show();

                @event.Add<Destroy>();
            }
        }
    }
}
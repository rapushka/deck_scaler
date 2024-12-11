using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnLevelCompletedShowMap : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SendLevelCompletedAfter>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var @event in _events)
            {
                if (!@event.IsElapsed<SendLevelCompletedAfter>())
                    continue;

                Progress.MarkLevelAsCompleted();
                HUD.MapView.Show();

                @event.Add<Destroy>();
            }
        }
    }
}
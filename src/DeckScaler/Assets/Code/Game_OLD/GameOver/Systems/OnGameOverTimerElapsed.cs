using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class OnGameOverTimerElapsed : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _gameOverTimers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<GameOverAfter>()
                    .Build()
            );

        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public void Execute()
        {
            foreach (var timer in _gameOverTimers)
            {
                if (timer.Get<GameOverAfter, Timer>().IsElapsed)
                    UiMediator.GameOver();
            }
        }
    }
}
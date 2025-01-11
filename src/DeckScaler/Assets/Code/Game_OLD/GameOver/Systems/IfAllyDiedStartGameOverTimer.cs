using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class IfAllyDiedStartGameOverTimer : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _deadAllies
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Ally>()
                    .And<Dead>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _gameOverTimers
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<GameOverAfter>()
                    .Build()
            );

        private static float Delay => Config.DelayBeforeGameOverScreenAppear;

        private static GameOverConfig Config => ServiceLocator.Resolve<IConfigs>().GameOver;

        public void Execute()
        {
            if (_gameOverTimers.Any())
                return;

            foreach (var _ in _deadAllies)
            {
                CreateEntity.Empty()
                    .Add<DebugName, string>("game over")
                    .Add<GameOverAfter, Timer>(new(Delay));

                return;
            }
        }
    }
}
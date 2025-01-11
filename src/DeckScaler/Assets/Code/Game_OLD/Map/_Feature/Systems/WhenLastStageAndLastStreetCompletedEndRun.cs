using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class WhenLastStageAndLastStreetCompletedEndRun : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        public void Execute()
        {
            foreach (var _ in _events)
            {
                var completedLastAvailableLevel = Progress.CurrentStreetIndex >= Config.CountOfStreets; // it's a workaround

                if (completedLastAvailableLevel)
                    StateMachine.Enter<GameVictoryState>();
            }
        }
    }
}
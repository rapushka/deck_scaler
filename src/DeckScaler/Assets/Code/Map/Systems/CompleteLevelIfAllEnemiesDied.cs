using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class CompleteLevelIfAllEnemiesDied : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _justDiedEnemies
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Enemy>()
                    .And<JustDied>()
                    .Build()
            );
        private readonly IGroup<Entity<Game>> _aliveEnemies
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Enemy>()
                    .Without<Dead>()
                    .Build()
            );

        private static MapConfig Map => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var _ in _justDiedEnemies)
            {
                if (_aliveEnemies.Any())
                    return;

                CreateEntity.Empty()
                    .Add<SendLevelCompletedAfter, Timer>(new(Map.DelayBeforeMapAppear))
                    ;
            }
        }
    }
}
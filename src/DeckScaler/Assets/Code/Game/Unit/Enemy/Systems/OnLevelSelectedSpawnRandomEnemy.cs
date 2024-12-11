using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnLevelSelectedSpawnRandomEnemy : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SelectNextLevel>()
                    .Build()
            );

        private static IUnitFactory EnemyFactory => ServiceLocator.Resolve<IFactories>().Unit;

        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Resolve<IConfigs>().Units;

        public void Execute()
        {
            foreach (var _ in _events)
            {
                var randomEnemyID = Random.PickRandom(Config.Enemies);
                EnemyFactory.CreateEnemy(randomEnemyID);
            }
        }
    }
}
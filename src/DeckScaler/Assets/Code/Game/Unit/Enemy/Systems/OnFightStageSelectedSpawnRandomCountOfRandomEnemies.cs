using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OnFightStageSelectedSpawnRandomCountOfRandomEnemies : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _selectedFightStages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<SelectStage>()
                    .And<FightStage>()
                    .Build()
            );

        private static IUnitFactory EnemyFactory => ServiceLocator.Resolve<IFactories>().Unit;

        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Resolve<IConfigs>().Units;

        public void Execute()
        {
            foreach (var _ in _selectedFightStages)
            {
                var randomCountOfEnemies = Random.RandomNumber(1, 3);
                for (var i = 0; i < randomCountOfEnemies; i++)
                {
                    var randomEnemyID = Random.PickRandom(Config.Enemies);
                    EnemyFactory.CreateEnemy(randomEnemyID);
                }
            }
        }
    }
}
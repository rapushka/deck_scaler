using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static IUnitFactory EnemyFactory => ServiceLocator.Resolve<IFactories>().Unit;

        private static IRandom PickRandom => ServiceLocator.Resolve<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Resolve<IConfigs>().Units;

        public void Initialize()
        {
            var randomEnemy = PickRandom.PickRandom(Config.Enemies);
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
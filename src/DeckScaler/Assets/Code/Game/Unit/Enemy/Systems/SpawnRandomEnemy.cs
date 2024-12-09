using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static IUnitFactory EnemyFactory => ServiceLocator.Get<IFactories>().Unit;

        private static IRandom PickRandom => ServiceLocator.Get<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Get<IConfigs>().Units;

        public void Initialize()
        {
            var randomEnemy = PickRandom.PickRandom(Config.Enemies);
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
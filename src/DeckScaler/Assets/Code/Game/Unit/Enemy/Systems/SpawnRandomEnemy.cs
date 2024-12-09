using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static IUnitFactory EnemyFactory => Services.Get<IFactories>().Unit;

        private static IRandom PickRandom => Services.Get<IRandom>();

        private static UnitsConfig Config => Services.Get<IConfigs>().Units;

        public void Initialize()
        {
            var randomEnemy = PickRandom.PickRandom(Config.Enemies);
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
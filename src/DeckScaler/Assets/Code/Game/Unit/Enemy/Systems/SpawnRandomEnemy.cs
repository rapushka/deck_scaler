using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static IUnitFactory EnemyFactory => Services.Get<IFactories>().Unit;

        public void Initialize()
        {
            var randomEnemy = Services.Get<IConfigs>().Units.Enemies.PickRandom();
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
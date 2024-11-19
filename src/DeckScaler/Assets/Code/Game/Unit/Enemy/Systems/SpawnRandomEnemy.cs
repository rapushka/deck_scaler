using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static IFactories EnemyFactory => Services.Get<IFactories>();

        public void Initialize()
        {
            var randomEnemy = Services.Get<IConfigs>().Units.Enemies.PickRandom();
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
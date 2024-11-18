using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private static UnitFactory EnemyFactory => Services.Get<Factories>().Unit;

        public void Initialize()
        {
            var randomEnemy = Services.Get<Configs>().Units.Enemies.PickRandom();
            EnemyFactory.CreateEnemy(randomEnemy.ID);
        }
    }
}
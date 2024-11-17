using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class SpawnRandomEnemy : IInitializeSystem
    {
        private readonly IGroup<Entity<Game>> _teamSlots = Contexts.Instance.GetGroup(
            MatcherBuilder<Game>
                .With<TeamSlot>()
                .Build()
        );

        private static UnitFactory EnemyFactory => Services.Get<Factories>().Unit;

        public void Initialize()
        {
            foreach (var slot in _teamSlots)
            {
                var randomEnemy = Services.Get<Configs>().Units.Enemies.PickRandom();
                EnemyFactory.CreateEnemy(randomEnemy.ID, slot);
            }
        }
    }
}
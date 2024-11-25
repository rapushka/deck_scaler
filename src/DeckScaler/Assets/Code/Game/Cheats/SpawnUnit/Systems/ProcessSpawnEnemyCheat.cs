using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class ProcessSpawnEnemyCheat : ProcessCheatBaseSystem<SpawnEnemy>
    {
        private static IFactories Factory => Services.Get<IFactories>();

        protected override bool TryProcess(Entity<Scopes.Cheats> entity, SpawnEnemy component)
        {
            var unitID = component.Value;
            Factory.CreateEnemy(unitID);

            return true;
        }
    }
}
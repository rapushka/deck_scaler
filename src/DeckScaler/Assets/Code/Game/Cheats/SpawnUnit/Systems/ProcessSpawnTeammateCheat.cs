using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class ProcessSpawnTeammateCheat : ProcessCheatBaseSystem<SpawnTeammate>
    {
        private static IFactories Factory => Services.Get<IFactories>();

        protected override bool TryProcess(Entity<Scopes.Cheats> entity, SpawnTeammate component)
        {
            var unitID = component.Value;
            Factory.CreateTeammate(unitID);

            return true;
        }
    }
}
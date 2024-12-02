using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class ProcessSpawnUnitCheat : ProcessCheatBaseSystem<SpawnUnit>
    {
        private static IUnitFactory Factory => Services.Get<IFactories>().Unit;

        protected override bool TryProcess(Entity<Scopes.Cheats> entity, SpawnUnit component)
        {
            var unitID = component.Value;
            var side = entity.Get<SpawnUnitAtSide>().Value;

            Factory.CreateAtSide(unitID, side);

            return true;
        }
    }
}
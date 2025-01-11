using System;
using DeckScaler.Cheats.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Cheats.Systems
{
    public class ProcessSpawnUnitCheat : ProcessCheatBaseSystem<SpawnUnit>
    {
        private static IUnitFactory Factory => ServiceLocator.Resolve<IFactories>().Unit;

        protected override bool TryProcess(Entity<Scopes.Cheats> entity, SpawnUnit component)
        {
            var unitID = component.Value;
            var side = entity.Get<SpawnUnitAtSide>().Value;

            CreateAtSide(unitID, side);
            return true;
        }

        private void CreateAtSide(UnitIDRef unitID, Side side)
        {
            if (side is Side.Enemy)
            {
                Factory.CreateEnemy(unitID);
                return;
            }

            if (side is Side.Player)
            {
                Factory.CreateTeammate(unitID);
                return;
            }

            throw new ArgumentException("Unknown Side");
        }
    }
}
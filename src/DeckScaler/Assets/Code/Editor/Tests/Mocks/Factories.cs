using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();

        public Entity<Game> CreateTeammate(UnitIDRef unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(UnitIDRef unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab) => CreateEntity.Next();
        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view)    => view.Entity;
    }
}
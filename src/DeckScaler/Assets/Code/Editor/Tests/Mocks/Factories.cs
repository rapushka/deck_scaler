using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();

        public Entity<Game> CreateTeammate(string unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(string unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour prefab) => CreateEntity.New();
    }
}
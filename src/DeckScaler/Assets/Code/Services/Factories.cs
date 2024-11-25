using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        Entity<Game> CreateTeammate(string unitID);
        Entity<Game> CreateEnemy(string unitID);

        Entity<Game> CreateTeamSlot();

        Entity<Game> CreateEntityBehaviour(EntityBehaviour prefab);
    }

    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();
        private readonly EntityBehaviourFactory _entityBehaviour = new();

        public Entity<Game> CreateTeammate(string unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(string unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour prefab) => _entityBehaviour.Create(prefab).Entity;
    }
}
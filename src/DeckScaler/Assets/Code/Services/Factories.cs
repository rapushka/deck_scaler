using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        Entity<Game> CreateTeammate(UnitIDRef unitID);
        Entity<Game> CreateEnemy(UnitIDRef unitID);

        Entity<Game> CreateTeamSlot();

        Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab);
        Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view);
    }

    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();
        private readonly EntityBehaviourFactory _entityBehaviour = new();

        public Entity<Game> CreateTeammate(UnitIDRef unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(UnitIDRef unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab) => _entityBehaviour.Create(prefab).Entity;
        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view)    => _entityBehaviour.Setup(view).Entity;
    }
}
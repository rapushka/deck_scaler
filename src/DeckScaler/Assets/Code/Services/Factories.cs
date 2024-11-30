using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        Entity<Game> CreateTeammate(UnitIDRef unitID);
        Entity<Game> CreateEnemy(UnitIDRef unitID);

        Entity<Game> CreateTeamSlot();

        Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab, Vector2 spawnPosition = default);
        Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view, Vector2 spawnPosition = default);
    }

    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();
        private readonly EntityBehaviourFactory _entityBehaviour = new();

        public Entity<Game> CreateTeammate(UnitIDRef unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(UnitIDRef unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab, Vector2 spawnPosition = default)
            => _entityBehaviour.Create(prefab, spawnPosition).Entity;

        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view, Vector2 spawnPosition = default)
            => _entityBehaviour.Setup(view).Entity;
    }
}
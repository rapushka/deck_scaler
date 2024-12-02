using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IFactories : IService
    {
        IUnitFactory Unit { get; }

        Entity<Game> CreateTeamSlot();

        Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab, Vector2 spawnPosition = default);
        Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view);
        Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view, Vector2 spawnPosition);
    }

    public class Factories : IFactories
    {
        private readonly TeamSlotFactory _teamSlot = new();
        private readonly EntityBehaviourFactory _entityBehaviour = new();

        public IUnitFactory Unit { get; } = new UnitFactory();

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => _entityBehaviour.Create(prefab, spawnPosition).Entity;

        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view, Vector2 spawnPosition)
            => _entityBehaviour.Setup(view).Entity;

        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view) => _entityBehaviour.Setup(view).Entity;
    }
}
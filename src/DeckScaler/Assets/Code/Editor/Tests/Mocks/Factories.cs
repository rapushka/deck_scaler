using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Factories : IFactories
    {
        private readonly UnitFactory _unit = new();
        private readonly TeamSlotFactory _teamSlot = new();

        public Entity<Game> CreateTeammate(UnitIDRef unitID) => _unit.CreateTeammate(unitID);

        public Entity<Game> CreateEnemy(UnitIDRef unitID) => _unit.CreateEnemy(unitID);

        public Entity<Game> CreateTeamSlot() => _teamSlot.Create();

        public Entity<Game> CreateEntityBehaviour(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => CreateEntity.Next()
                .Replace<WorldPosition, Vector2>(spawnPosition);

        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view, Vector2 spawnPosition)
            => view.Entity
                .Replace<WorldPosition, Vector2>(spawnPosition);

        public Entity<Game> SetupEntityBehaviour(EntityBehaviour<Game> view) => view.Entity;
    }
}
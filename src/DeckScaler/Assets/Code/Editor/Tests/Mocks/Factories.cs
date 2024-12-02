using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Factories : IFactories
    {
        private readonly TeamSlotFactory _teamSlot = new();

        public IUnitFactory Unit { get; } = new UnitFactory();

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
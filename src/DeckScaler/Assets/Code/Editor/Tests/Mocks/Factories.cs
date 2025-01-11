using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Editor.Tests.Mocks
{
    public class Factories : IFactories
    {
        public IUnitFactory            Unit            { get; } = new UnitFactory();
        public IEntityBehaviourFactory EntityBehaviour { get; } = new MockEntityBehaviourFactory();
        public IAffectsFactory         Affects         { get; } = new AffectsFactory();
        public ITrinketFactory         Trinkets        { get; } = new TrinketFactory();
    }

    public class MockEntityBehaviourFactory : IEntityBehaviourFactory
    {
        public Entity<Game> Create(EntityBehaviour<Game> prefab, Vector2 spawnPosition)
            => CreateEntity.Next().Replace<WorldPosition, Vector2>(spawnPosition);

        public Entity<Game> Setup(EntityBehaviour<Game> view, Vector2 spawnPosition)
            => view.Entity.Replace<WorldPosition, Vector2>(spawnPosition);

        public Entity<Game> Register(EntityBehaviour<Game> view)
            => view.Entity;
    }
}
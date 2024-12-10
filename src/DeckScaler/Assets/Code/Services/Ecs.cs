using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler.Service
{
    public interface IEcs : IService
    {
        void Initialize();
        void CreateFeature();

        void Dispose();
        void MarkAllEntitiesAsDestroyed();
    }

    public class Ecs : IEcs
    {
        private GameplayFeatureAdapter _featureAdapter;
        private CustomIndexes _customIndexes;

        public void Initialize()
        {
            var contexts = Contexts.Instance;

            contexts.InitializeScope<Game>();
            contexts.InitializeScope<Scopes.Cheats>();
            contexts.InitializeScope<Input>();

            contexts.Get<Game>().GetPrimaryIndex<ID, EntityID>().Initialize();
            contexts.Get<Game>().GetPrimaryIndex<Inventory, Side>().Initialize();

            _customIndexes = new(contexts);
            _customIndexes.Initialize();

#if DEBUG
            Entity<Game>.Formatter = new GameEntityFormatter();
#endif
        }

        public void CreateFeature()
        {
            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();
            _featureAdapter.Init(this);
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }

        public void MarkAllEntitiesAsDestroyed()
        {
            var contexts = Contexts.Instance;

            foreach (var entity in contexts.Get<Game>().GetEntities())
                entity.Is<Destroy>(true);

            foreach (var entity in contexts.Get<Input>().GetEntities())
                entity.Is<Destroy>(true);
        }
    }
}
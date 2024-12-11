using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler
{
    public interface IEcsRunner : IService
    {
        void AddFeature<TFeature>() where TFeature : Feature, new();

        void Update();

        void RemoveFeature<TFeature>(bool destroyAllEntities) where TFeature : Feature;
    }

    public class EcsRunner : IEcsRunner
    {
        private readonly Dictionary<Type, Feature> _features = new();

        public void AddFeature<TFeature>()
            where TFeature : Feature, new()
        {
            var newFeature = new TFeature();
            _features.Add(typeof(TFeature), newFeature);

            newFeature.Initialize();
        }

        public void RemoveFeature<TFeature>(bool destroyAllEntities)
            where TFeature : Feature
        {
            var type = typeof(TFeature);
            var feature = _features[type];

            Dispose(feature, destroyAllEntities);
            _features.Remove(type);
        }

        public void Update()
        {
            foreach (var (_, feature) in _features)
            {
                feature.Execute();
                feature.Cleanup();
            }
        }

        private void Dispose(Feature feature, bool destroyAllEntities)
        {
            feature.DeactivateReactiveSystems();
            feature.ClearReactiveSystems();

            if (destroyAllEntities)
                MarkAllEntitiesAsDestroyed();

            feature.Cleanup();
            feature.TearDown();
        }

        private void MarkAllEntitiesAsDestroyed()
        {
            var contexts = Contexts.Instance;
            foreach (var entity in contexts.Get<Game>().GetEntities())
                entity.Is<Destroy>(true);

            foreach (var entity in contexts.Get<Input>().GetEntities())
                entity.Is<Destroy>(true);
        }
    }
}
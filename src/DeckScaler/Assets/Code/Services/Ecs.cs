using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IEcs
        : IService
    {
        void Init();
        void Dispose();
    }

    public class Ecs : IEcs
    {
        private GameplayFeatureAdapter _featureAdapter;

        public void Init()
        {
            Contexts.Instance.InitializeScope<Game>();

            Contexts.Instance.Get<Game>().GetPrimaryIndex<ID, EntityID>().Initialize();

            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();

#if DEBUG
            Entity<Game>.Formatter = new ModelEntityFormatter();
#endif
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }
    }
}
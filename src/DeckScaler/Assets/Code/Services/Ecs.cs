using DeckScaler.Component;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public class Ecs : IService
    {
        private GameplayFeatureAdapter _featureAdapter;

        public void Init()
        {
            Contexts.Instance.InitializeScope<Model>();
            Contexts.Instance.InitializeScope<View>();

            Contexts.Instance.Get<Model>().GetPrimaryIndex<ID, EntityIDBase>().Initialize();

            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();

#if DEBUG
            Entity<Model>.Formatter = new ModelEntityFormatter();
            Entity<View>.Formatter = new ViewEntityFormatter();
#endif
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }
    }
}
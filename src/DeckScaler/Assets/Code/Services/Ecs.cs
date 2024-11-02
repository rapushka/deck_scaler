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

            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();

#if DEBUG
            Entity<Model>.Formatter = new ModelEntityFormatter();
#endif
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }
    }
}
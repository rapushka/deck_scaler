using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public class Ecs
    {
        private GameplayFeatureAdapter _featureAdapter;

        public void Init()
        {
            Contexts.Instance.InitializeScope<Scope>();

            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }
    }
}
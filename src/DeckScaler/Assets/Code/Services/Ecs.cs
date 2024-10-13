using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public class Ecs : IService
    {
        private GameplayFeatureAdapter _featureAdapter;

        public void Init()
        {
            Contexts.Instance.InitializeScope<Scope>();

            var go = new GameObject("Gameplay Feature");
            _featureAdapter = go.AddComponent<GameplayFeatureAdapter>();

#if DEBUG
            Entity.Formatter = new Formatter();
#endif
        }

        public void Dispose()
        {
            Object.Destroy(_featureAdapter.gameObject);
        }
    }
}
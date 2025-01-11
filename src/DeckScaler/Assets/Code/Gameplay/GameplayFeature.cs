using Entitas;
using UnityEngine;

namespace DeckScaler
{
    public class GameplayFeature : Feature
    {
        public GameplayFeature()
            : base(nameof(GameplayFeature))
        {
            Add(new TestSystem());
        }

        private class TestSystem : IInitializeSystem
        {
            public void Initialize()
            {
                Debug.Log("hello");
            }
        }
    }
}
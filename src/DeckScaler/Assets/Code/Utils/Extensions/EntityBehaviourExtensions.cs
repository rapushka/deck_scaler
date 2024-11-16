using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public static class EntityBehaviourExtensions
    {
        public static T Spawn<T>(this T original)
            where T : EntityBehaviourBase
        {
            var behaviour = Object.Instantiate(original);
            behaviour.Register(Contexts.Instance);
            return behaviour;
        }

        public static T Spawn<T>(this T original, Vector3 position)
            where T : EntityBehaviourBase
        {
            var behaviour = Object.Instantiate(original, position, Quaternion.identity);
            behaviour.Register(Contexts.Instance);
            return behaviour;
        }

        public static T Spawn<T>(this T original, Transform parent) where T : EntityBehaviourBase
        {
            var behaviour = Object.Instantiate(original, parent);
            behaviour.Register(Contexts.Instance);
            return behaviour;
        }
    }
}
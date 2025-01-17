using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DeckScaler
{
    public static class GameObjectExtensions
    {
        public static void SetActive(this MonoBehaviour @this, bool value) => @this.gameObject.SetActive(value);

        public static bool IsActive(this MonoBehaviour @this, bool inHierarchy = false)
            => @this.gameObject.IsActive(inHierarchy);

        public static bool IsActive(this GameObject @this, bool inHierarchy = false)
            => inHierarchy
                ? @this.activeInHierarchy
                : @this.activeSelf;

        public static void DestroyObject(this MonoBehaviour @this)
        {
            if (@this != null)
            {
                (@this as IDisposable)?.Dispose();
                @this.gameObject.DestroyObject();
            }
        }

        public static void DestroyObject(this GameObject @this)
        {
            if (@this == null)
                return;

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(@this);
                return;
            }
#endif

            Object.Destroy(@this);
        }

        [CanBeNull]
        public static T Nullable<T>(this T @this)
            where T : Object
            => @this == null ? null : @this;
    }
}
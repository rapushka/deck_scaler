using UnityEngine;

namespace DeckScaler
{
    public static class GameObjectExtensions
    {
        public static void SetActive(this MonoBehaviour @this, bool value) => @this.gameObject.SetActive(value);

        public static bool IsActive(this MonoBehaviour @this, bool inHierarchy = false)
            => inHierarchy
                ? @this.gameObject.activeInHierarchy
                : @this.gameObject.activeSelf;

        public static void DestroyObject(this MonoBehaviour @this)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                Object.DestroyImmediate(@this.gameObject);
                return;
            }
#endif

            Object.Destroy(@this.gameObject);
        }
    }
}
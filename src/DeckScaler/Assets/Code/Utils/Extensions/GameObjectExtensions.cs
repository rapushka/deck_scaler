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
    }
}
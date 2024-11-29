using UnityEngine;

namespace DeckScaler.Utils
{
    public static class MathExtensions
    {
        public static bool ApproximatelyEquals(this Vector2 @this, Vector2 other)
            => @this.x.ApproximatelyEquals(other.x)
                && @this.y.ApproximatelyEquals(other.y);

        public static bool ApproximatelyEquals(this float @this, float other) => Mathf.Approximately(@this, other);
    }
}
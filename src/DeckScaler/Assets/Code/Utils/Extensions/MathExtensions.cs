using UnityEngine;

namespace DeckScaler
{
    public static class MathExtensions
    {
        public static bool ApproximatelyEquals(this Vector2 @this, Vector2 other)
            => @this.x.ApproximatelyEquals(other.x)
                && @this.y.ApproximatelyEquals(other.y);

        public static bool ApproximatelyEquals(this float @this, float other) => Mathf.Approximately(@this, other);

        public static int SignInt(this float @this)
        {
            return @this.ApproximatelyEquals(0f) ? 0
                : (double)@this >= 0             ? 1
                                                   : -1;
        }

        public static float Abs(this float @this) => Mathf.Abs(@this);

        public static int Abs(this int @this) => Mathf.Abs(@this);

        public static float Clamp(this float @this, float? min, float? max) => Mathf.Clamp(@this, min ?? @this, max ?? @this);
    }
}
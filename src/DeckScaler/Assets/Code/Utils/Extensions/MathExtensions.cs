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
            => @this.ApproximatelyEquals(0f) ? Constants.Sign.Center
                : @this >= 0d                ? Constants.Sign.Right
                                               : Constants.Sign.Left;

        public static int Sign(this int @this)
            => @this == 0    ? Constants.Sign.Center
                : @this >= 0 ? Constants.Sign.Right
                               : Constants.Sign.Left;

        public static float Abs(this float @this) => Mathf.Abs(@this);

        public static int Abs(this int @this) => Mathf.Abs(@this);

        public static float Clamp(this float @this, float? min = null, float? max = null)
            => Mathf.Clamp(@this, min ?? @this, max ?? @this);

        public static int Clamp(this int @this, int? min = null, int? max = null)
            => Mathf.Clamp(@this, min ?? @this, max ?? @this);
    }
}
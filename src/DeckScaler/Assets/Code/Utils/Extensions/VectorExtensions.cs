using UnityEngine;

namespace DeckScaler.Utils
{
    public static class VectorExtensions
    {
        public static Vector3 Extend(this Vector2 vector2, float z) => new(vector2.x, vector2.y, z);

        public static Vector2 Flat(this Vector3 vector3) => new(vector3.x, vector3.y);

        public static Vector3 With(this Vector3 @this, float? x = null, float? y = null, float? z = null)
        {
            if (x is not null)
                @this.x = x.Value;

            if (y is not null)
                @this.x = y.Value;

            if (z is not null)
                @this.x = z.Value;

            return @this;
        }
    }
}
using UnityEngine;

namespace DeckScaler.Utils
{
    public static class TransformExtensions
    {
        public static void SetGlobalPosition(this Transform @this, float? x = null, float? y = null, float? z = null)
        {
            var position = @this.position;

            if (x is not null)
                position.x = x.Value;

            if (y is not null)
                position.y = y.Value;

            if (z is not null)
                position.z = z.Value;

            @this.position = position;
        }

        public static void SetLocalPosition(this Transform @this, float? x = null, float? y = null, float? z = null)
        {
            var localPosition = @this.localPosition;

            if (x is not null)
                localPosition.x = x.Value;

            if (y is not null)
                localPosition.y = y.Value;

            if (z is not null)
                localPosition.z = z.Value;

            @this.localPosition = localPosition;
        }
    }
}
using UnityEngine;

namespace DeckScaler
{
    public struct TransformData
    {
        public Vector3 LocalPosition;
        public Vector3 LocalScale;
        public Quaternion LocalRotation;

        public TransformData(Transform transform)
        {
            LocalPosition = transform.localPosition;
            LocalScale = transform.localScale;
            LocalRotation = transform.localRotation;
        }
    }

    public static class TransformDataExtensions
    {
        public static TransformData Save(this Transform @this) => new(@this);

        public static void Load(this Transform @this, TransformData data)
        {
            @this.localPosition = data.LocalPosition;
            @this.localScale = data.LocalScale;
            @this.localRotation = data.LocalRotation;
        }
    }
}
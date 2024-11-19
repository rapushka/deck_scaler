using UnityEngine;

namespace DeckScaler.Utils
{
    public static class VectorExtensions
    {
        public static Vector3 WithZ(this Vector2 vector2, float z) => new(vector2.x, vector2.y, z);
    }
}
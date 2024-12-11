using UnityEngine;

namespace DeckScaler
{
    public static class ColorExtensions
    {
        public static Gradient AsGradient(this Color color)
            => new()
            {
                colorKeys = new GradientColorKey[] { new(color, 0f), new(color, 1f), },
                alphaKeys = new GradientAlphaKey[] { new(1f, 0f), new(1f, 1f), },
            };
    }
}
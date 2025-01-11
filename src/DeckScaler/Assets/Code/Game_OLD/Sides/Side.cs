using System;

namespace DeckScaler
{
    public enum Side
    {
        Unknown = 0,
        Player = 1,
        Enemy = 2,
    }

    public static class SideExtensions
    {
        // ReSharper disable once SwitchExpressionHandlesSomeKnownEnumValuesWithExceptionInDefault - this is intentionally! fuck you!
        public static Side Flip(this Side side) =>
            side switch
            {
                Side.Player => Side.Enemy,
                Side.Enemy  => Side.Player,
                _           => throw new ArgumentException("Side is unknown!"),
            };
    }
}
using System;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler
{
    [Serializable]
    public enum Suit
    {
        Unknown = 0,
        Spades = 1,
        Hearts = 2,
        Clubs = 3,
        Diamonds = 4,
    }

    public static class SuitExtensions
    {
        public static bool InSuit(this Entity<Game> @this, Suit other)
            => @this.Get<Component.Suit, Suit>().Is(other);

        public static bool InSuit<TComponent>(this Entity<Game> @this, Suit other)
            where TComponent : ValueComponent<Suit>, IInScope<Game>, new()
            => @this.Get<TComponent, Suit>().Is(other);

        public static bool Is(this Suit @this, Suit other) // Just in case I'll want to add wildcards:)
        {
            Validate(@this, other);
            return @this == other;
        }

        private static void Validate(Suit @this, Suit other)
        {
#if UNITY_EDITOR
            if (@this is Suit.Unknown || other is Suit.Unknown)
                throw new InvalidOperationException("Unknown Suit");
#endif
        }

        public static string ToIcon(this Suit suit)
            => suit switch
            {
                Suit.Unknown  => "UNKNOWN",
                Suit.Spades   => "\u2660",
                Suit.Hearts   => "\u2665",
                Suit.Clubs    => "\u2663",
                Suit.Diamonds => "\u2666",
                _             => throw new ArgumentOutOfRangeException(nameof(suit), suit, null),
            };
    }
}
using System;

namespace DeckScaler
{
    public static class SuitsExtensions
    {
        public static string ToIcon(this Suit suit)
            => suit switch
            {
                Suit.Unknown  => "UNKNOWN",
                Suit.Spades   => "\u2660",
                Suit.Hearts   => "\u2665",
                Suit.Clubs    => "\u2663",
                Suit.Diamonds => "\u2666",
                _             => throw new ArgumentOutOfRangeException(nameof(suit), suit, null)
            };
    }
}
using System;
using DeckScaler;

namespace DeckScaler
{
    [Serializable]
    public class StatsData : SerializableDictionary<Suit, int> { }
}
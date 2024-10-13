using System;
using DeckScaler.Utils;

namespace DeckScaler
{
    [Serializable]
    public class StatsData : SerializableDictionary<Suit, int> { }
}
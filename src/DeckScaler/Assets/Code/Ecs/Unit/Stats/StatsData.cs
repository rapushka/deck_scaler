using System;
using DeckScaler;
using SmartIdTable;

namespace DeckScaler
{
    [Serializable]
    public class StatsData : SerializedDictionary<Suit, int> { }
}
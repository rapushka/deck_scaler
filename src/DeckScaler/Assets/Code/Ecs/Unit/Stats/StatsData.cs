using System;
using SmartIdTable;

namespace DeckScaler
{
    [Serializable]
    public class StatsData : SerializedDictionary<Suit, int> { }
}
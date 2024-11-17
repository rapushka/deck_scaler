using System;
using System.Linq;
using SmartIdTable;

namespace DeckScaler
{
    [Serializable]
    public class StatsData : SerializedDictionary<Suit, int>
    {
        public override string ToString()
            => string.Join(", ", this.Select(kvp => $"{kvp.Key.ToIcon()}: {kvp.Value}"));
    }
}
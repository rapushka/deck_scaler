using System;
using System.Linq;
using SmartIdTable;
using UnityEngine;

namespace DeckScaler
{
    public enum Stat
    {
        Unknown = 0,
        MaxHealth = 1,
        BaseDamage = 2,
        Power = 3,
    }

    [Serializable]
    public class StatsData
    {
        [SerializeField] private SerializedDictionary<Stat, int> _stats;

        public StatsData()
        {
            var dictionary = Enum.GetValues(typeof(Stat))
                .Cast<Stat>()
                .Where((s) => s is not Stat.Unknown)
                .ToDictionary((s) => s, (_) => 0);
            _stats = new(dictionary);
        }

        public int this[Stat index]
        {
            get => _stats[index];
            set => _stats[index] = value;
        }

        public StatsData With(Stat stat, int value)
        {
            this[stat] = value;
            return this;
        }

        public override string ToString() => _stats.JoinString();
    }
}
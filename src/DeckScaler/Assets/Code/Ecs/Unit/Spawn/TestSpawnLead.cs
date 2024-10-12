using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using UnityEngine;

namespace DeckScaler.System
{
    public sealed class TestSpawnLead : IInitializeSystem
    {
        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Initialize()
        {
            var config = UnitsConfig.UnitConfigs["bouncer"];

            UnitsConfig.UnitViewPrefab
                       .Spawn()
                       .Entity
                       .Add<Name, string>("Test Lead")
                       .Is<Lead>(true)
                       .Add<Component.Suit, Suit>(config.Suit)
                       .Add<Portrait, Sprite>(config.Portrait)
                       .Add<Health, int>(config.Health)
                       .Add<Component.Stats, StatsData>(config.StatsData)
                ;
        }
    }
}
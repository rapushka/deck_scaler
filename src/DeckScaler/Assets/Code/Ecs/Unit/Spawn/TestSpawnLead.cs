using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class TestSpawnLead : IInitializeSystem
    {
        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Initialize()
        {
            var unitID = "bouncer";
            var config = UnitsConfig.UnitConfigs[unitID];

            UnitsConfig.UnitViewPrefab
                       .Spawn()
                       .Entity
                       .Add<Name, string>("Test Lead")
                       .Add<UnitID, string>(unitID)
                       .Is<Lead>(true)
                       .Is<Ally>(true)
                       .Add<Component.Suit, Suit>(config.Suit)
                       .Add<Portrait, Sprite>(config.Portrait)
                       .Add<Health, int>(config.Health)
                       .Add<Component.Stats, StatsData>(config.StatsData)
                ;
        }
    }
}
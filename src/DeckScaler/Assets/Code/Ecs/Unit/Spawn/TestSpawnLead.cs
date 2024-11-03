using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class TestSpawnLead : IInitializeSystem
    {
        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Initialize()
        {
            return;

            var unitID = "bouncer";
            var config = UnitsConfig.UnitConfigs[unitID];

            var entity = Contexts.Instance.Get<Model>().CreateEntity()
                                 .Add<Name, string>("Test Lead")
                                 .Add<UnitID, string>(unitID)
                                 .Is<Lead>(true)
                                 .Is<Ally>(true)
                                 .Add<Component.Suit, Suit>(config.Suit)
                                 .Add<Health, int>(config.Health)
                                 .Add<Component.Stats, StatsData>(config.StatsData)
                ;

            UnitsConfig.UnitViewPrefab
                       .Spawn()
                       .Entity
                       .Add<Name, string>("Test Lead")
                       .AddModel(entity)
                       .Add<Portrait, Sprite>(config.Portrait)
                ;
        }
    }
}
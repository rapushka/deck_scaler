using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Model>;
using UnitID = DeckScaler.Component.UnitID;

namespace DeckScaler.Systems
{
    public sealed class SpawnEnemyForEachAlly : IInitializeSystem
    {
        private readonly IGroup<Entity<Model>> _allies = Contexts.Instance.Get<Model>().GetGroup(Get<Ally>());

        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Initialize()
        {
            return;

            var unitID = "rat";
            var config = UnitsConfig.EnemyConfigs[unitID];

            foreach (var ally in _allies)
            {
                var entity = Contexts.Instance.Get<Model>().CreateEntity()
                                     .Add<Name, string>("Test enemy")
                                     .Add<UnitID, string>(unitID)
                                     .Is<Enemy>(true)
                                     .Add<Component.Suit, Suit>(config.Suit)
                                     .Add<Health, int>(config.Health)
                                     .Add<Stats, StatsData>(config.StatsData)
                                     .Add<Opponent, Entity<Model>>(ally);

                var view = UnitsConfig.UnitViewPrefab
                                      .Spawn()
                                      .Entity
                                      .AddModel(entity)
                                      .Add<Name, string>("Test enemy")
                                      .Add<Portrait, Sprite>(config.Portrait)
                    ;

                ally.Add<Opponent, Entity<Model>>(entity);
            }
        }
    }
}
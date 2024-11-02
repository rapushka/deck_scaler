using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Scope>;
using UnitID = DeckScaler.Component.UnitID;

namespace DeckScaler.Systems
{
    public sealed class SpawnEnemyForEachAlly : IInitializeSystem
    {
        private readonly IGroup<Entity<Scope>> _allies = Contexts.Instance.Scope().GetGroup(Get<Ally>());

        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Initialize()
        {
            return;
            
            var unitID = "rat";
            var config = UnitsConfig.EnemyConfigs[unitID];

            foreach (var ally in _allies)
            {
                var entity = UnitsConfig.UnitViewPrefab
                                        .Spawn()
                                        .Entity
                                        .Add<Name, string>("Test enemy")
                                        .Add<UnitID, string>(unitID)
                                        .Is<Enemy>(true)
                                        .Add<Component.Suit, Suit>(config.Suit)
                                        .Add<Portrait, Sprite>(config.Portrait)
                                        .Add<Health, int>(config.Health)
                                        .Add<Stats, StatsData>(config.StatsData)
                                        .Add<Opponent, Entity<Scope>>(ally)
                    ;

                ally.Add<Opponent, Entity<Scope>>(entity);
            }
        }
    }
}
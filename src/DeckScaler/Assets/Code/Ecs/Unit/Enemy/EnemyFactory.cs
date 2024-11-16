using System;
using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class EnemyFactory
    {
        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Foo()
        {
            throw new NotImplementedException();

            var unitID = "rat";
            var config = UnitsConfig[unitID];

            var _allies = (IEnumerable<Entity<Game>>)null;
            foreach (var ally in _allies)
            {
                var entity = Contexts.Instance.Get<Game>().CreateEntity()
                                     .Add<Name, string>("Test enemy")
                                     .Add<UnitID, string>(unitID)
                                     .Is<Component.Enemy>(true)
                                     .Add<Component.Suit, Suit>(config.Suit)
                                     .Add<Health, int>(config.Health)
                                     .Add<Stats, StatsData>(config.StatsData)
                                     .Add<Opponent, EntityID>(ally.ID());

                var view = UnitsConfig.ViewPrefab
                                      .Spawn()
                                      .Entity
                                      .Add<Name, string>("Test enemy")
                    // .Add<Portrait, Sprite>(config.Portrait)
                    ;

                ally.Add<Opponent, EntityID>(entity.ID());
            }
        }
    }
}
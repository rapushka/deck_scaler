using DeckScaler.Component;
using DeckScaler.Service;
using DeckScaler.Utils;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler
{
    public class LeadFactory
    {
        private static UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        public void Create(string leadID)
        {
            var config = UnitsConfig[leadID];

            Contexts.Instance.Get<Model>().CreateEntity()
                    .Add<Name, string>("Test Lead")
                    .Add<UnitID, string>(leadID)
                    .Is<Lead>(true)
                    .Is<Ally>(true)
                    .Add<Component.Suit, Suit>(config.Suit)
                    .Add<Health, int>(config.Health)
                    .Add<Stats, StatsData>(config.StatsData)
                ;
        }
    }
}
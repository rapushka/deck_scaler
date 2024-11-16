using DeckScaler.Component;
using DeckScaler.Utils;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class UnitFactory
    {
        private IDebug Debug => Services.Get<IDebug>();

        private UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        private TeamSlotFactory TeamSlotFactory => Services.Get<Factories>().TeamSlot;

        public Entity<Model> CreateTeammate(string unitID)
        {
            var config = UnitsConfig[unitID];
            var unitType = config.Type;
            Debug.Assert(unitType is not UnitType.Enemy);

            var slot = TeamSlotFactory.Create();

            // TODO: portraits
            return CreateEntity.New<Model>()
                               .Add<Name, string>(config.ID) // TODO: localization
                               .Add<UnitID, string>(config.ID)
                               .Is<Lead>(unitType is UnitType.Lead)
                               .Is<Teammate>(true)
                               .Is<Ally>(true)
                               .Add<Component.Suit, Suit>(config.Suit)
                               .Add<Health, int>(config.Health)
                               .Add<Stats, StatsData>(config.StatsData)
                               .SetupToSlotAsTeammate(slot)
                ;
        }
    }
}
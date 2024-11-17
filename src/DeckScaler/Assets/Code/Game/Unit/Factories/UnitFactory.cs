using DeckScaler.Component;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class UnitFactory
    {
        private IDebug Debug => Services.Get<IDebug>();

        private UnitsConfig UnitsConfig => Services.Get<Configs>().Units;

        private TeamSlotFactory TeamSlotFactory => Services.Get<Factories>().TeamSlot;

        public Entity<Game> CreateTeammate(string unitID)
        {
            var slot = TeamSlotFactory.Create();

            return CreateUnit(unitID)
                    .SetupToSlotAsTeammate(slot)
                ;
        }

        public Entity<Game> CreateEnemy(string unitID, Entity<Game> teamSlot)
        {
            return CreateUnit(unitID)
                    .SetupToSlotAsEnemy(teamSlot)
                ;
        }

        private Entity<Game> CreateUnit(string unitID)
        {
            var config = UnitsConfig[unitID];
            var unitType = config.Type;

            return CreateEntity.New()
                               .Add<Name, string>(config.ID)
                               .Add<UnitID, string>(config.ID)
                               .Is<Lead>(unitType is UnitType.Lead)
                               .Is<Enemy>(unitType is UnitType.Enemy)
                               .Is<Teammate>(unitType is UnitType.Ally)
                               .Is<Ally>(unitType is UnitType.Ally)
                               .Add<Component.Suit, Suit>(config.Suit)
                               .Add<Health, int>(config.Health)
                               .Add<Stats, StatsData>(config.StatsData)
                               .Is<Loading>(true)
                               .Add<PrefabToLoad, EntityBehaviour>(UnitsConfig.ViewPrefab);
        }
    }
}
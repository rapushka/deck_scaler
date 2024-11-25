using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;

namespace DeckScaler.Service
{
    public class UnitFactory
    {
        private UnitsConfig UnitsConfig => Services.Get<IConfigs>().Units;

        private IFactories Factory => Services.Get<IFactories>();

        public Entity<Game> CreateTeammate(string unitID)
        {
            return CreateUnit(unitID);
        }

        public Entity<Game> CreateEnemy(string unitID)
        {
            return CreateUnit(unitID);
        }

        private Entity<Game> CreateUnit(string unitID)
        {
            var config = UnitsConfig[unitID];
            var unitType = config.Type;

            return Factory.CreateEntityBehaviour(UnitsConfig.ViewPrefab)
                          .Add<Name, string>(config.ID)
                          .Add<UnitID, string>(config.ID)
                          .Is<Lead>(unitType is UnitType.Lead)
                          .Is<Enemy>(unitType is UnitType.Enemy)
                          .Is<Teammate>(unitType is UnitType.Ally or UnitType.Lead)
                          .Is<Ally>(unitType is UnitType.Ally)
                          .Add<Component.Suit, Suit>(config.Suit)
                          .Add<Health, int>(config.Health)
                          .Add<MaxHealth, int>(config.Health)
                          .Add<BaseDamage, int>(config.BaseDamage)
                          .Add<Stats, StatsData>(config.StatsData)
                          .Is<Queued>(true);
        }
    }
}
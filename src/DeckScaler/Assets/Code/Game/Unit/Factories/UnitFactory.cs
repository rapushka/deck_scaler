using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public class UnitFactory
    {
        private UnitsConfig UnitsConfig => Services.Get<IConfigs>().Units;

        private IFactories Factory => Services.Get<IFactories>();

        private static UnitViewConfig ViewConfig => Services.Get<IConfigs>().UnitView;

        public Entity<Game> CreateTeammate(UnitIDRef unitID) => CreateUnit(unitID, ViewConfig.TeammateSpawnOffset);

        public Entity<Game> CreateEnemy(UnitIDRef unitID) => CreateUnit(unitID, ViewConfig.EnemySpawnOffset);

        private Entity<Game> CreateUnit(UnitIDRef unitID, Vector2 spawnPosition)
        {
            var config = UnitsConfig[unitID];
            var unitType = config.Type;

            return Factory.CreateEntityBehaviour(UnitsConfig.ViewPrefab, spawnPosition)
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
                    .Is<Queued>(true)
                ;
        }
    }
}
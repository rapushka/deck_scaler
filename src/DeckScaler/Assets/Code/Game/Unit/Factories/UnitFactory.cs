using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IUnitFactory
    {
        Entity<Game> CreateLead(UnitIDRef unitID);
        Entity<Game> CreateTeammate(UnitIDRef unitID);
        Entity<Game> CreateEnemy(UnitIDRef unitID);

        Entity<Game> CreateUnit(UnitIDRef unitID);
    }

    public class UnitFactory : IUnitFactory
    {
        private UnitsConfig UnitsConfig => ServiceLocator.Resolve<IConfigs>().Units;

        private IFactories Factory => ServiceLocator.Resolve<IFactories>();

        private static UnitViewConfig ViewConfig => ServiceLocator.Resolve<IConfigs>().UnitView;

        private static UnitsUtil Utils => ServiceLocator.Resolve<IUtils>().Units;

        public Entity<Game> CreateLead(UnitIDRef unitID)
            => CreateTeammate(unitID)
                .Is<Lead>(true)
                .Bump();

        public Entity<Game> CreateTeammate(UnitIDRef unitID)
            => Utils.AddAllyComponents(CreateUnit(unitID, ViewConfig.TeammateSpawnOffset));

        public Entity<Game> CreateEnemy(UnitIDRef unitID)
            => CreateUnit(unitID, ViewConfig.EnemySpawnOffset)
                .Is<Enemy>(true)
                .Add<OnSide, Side>(Side.Enemy)
                .Bump();

        public Entity<Game> CreateUnit(UnitIDRef unitID)
            => CreateUnit(unitID, ViewConfig.EnemySpawnOffset);

        private Entity<Game> CreateUnit(UnitIDRef unitID, Vector2 spawnPosition)
        {
            var config = UnitsConfig[unitID];
            var stats = config.Stats;

            return Factory.EntityBehaviour.Create(UnitsConfig.ViewPrefab, spawnPosition)
                    .Replace<DebugName, string>(ShortUnitID(config.ID))
                    .Add<Unit, string>(config.ID)
                    .Add<SpriteSortOrder, int>(ViewConfig.SortingOrder.Idle)
                    .Add<Component.Suit, Suit>(config.Suit)
                    .Add<Price, int>(config.Price)

                    // stats
                    .Add<BaseStats, StatsData>(stats)
                    .Add<Health, int>(stats[Stat.MaxHealth])
                    .Add<MaxHealth, int>(stats[Stat.MaxHealth])
                    .Add<Damage, int>(stats[Stat.BaseDamage])
                    .Add<Power, int>(stats[Stat.Power])
                ;
        }

        private string ShortUnitID(string source)
        {
#if UNITY_EDITOR
            return source
                .Remove(Constants.TableID.Allies)
                .Remove(Constants.TableID.Enemies);
#else
            return source;
#endif
        }
    }
}
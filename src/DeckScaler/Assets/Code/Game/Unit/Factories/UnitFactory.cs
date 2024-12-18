using System;
using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Service
{
    public interface IUnitFactory
    {
        Entity<Game> CreateAtSide(UnitIDRef unitID, Side side);

        Entity<Game> CreateLead(UnitIDRef unitID);
        Entity<Game> CreateTeammate(UnitIDRef unitID);
        Entity<Game> CreateEnemy(UnitIDRef unitID);
    }

    public class UnitFactory : IUnitFactory
    {
        private UnitsConfig UnitsConfig => ServiceLocator.Resolve<IConfigs>().Units;

        private IFactories Factory => ServiceLocator.Resolve<IFactories>();

        private static UnitViewConfig ViewConfig => ServiceLocator.Resolve<IConfigs>().UnitView;

        public Entity<Game> CreateAtSide(UnitIDRef unitID, Side side)
        {
            if (side is Side.Enemy)
                return CreateEnemy(unitID);

            if (side is Side.Player)
                return CreateTeammate(unitID);

            throw new ArgumentException("Unknown Side");
        }

        public Entity<Game> CreateLead(UnitIDRef unitID)
            => CreateTeammate(unitID)
                .Is<Lead>(true);

        public Entity<Game> CreateTeammate(UnitIDRef unitID)
            => CreateUnit(unitID, ViewConfig.TeammateSpawnOffset)
                .Is<Draggable>(true)
                .Is<Teammate>(true)
                .Is<Ally>(true)
                .Add<OnSide, Side>(Side.Player);

        public Entity<Game> CreateEnemy(UnitIDRef unitID)
            => CreateUnit(unitID, ViewConfig.EnemySpawnOffset)
                .Is<Enemy>(true)
                .Add<OnSide, Side>(Side.Enemy);

        private Entity<Game> CreateUnit(UnitIDRef unitID, Vector2 spawnPosition)
        {
            var config = UnitsConfig[unitID];
            var stats = config.Stats;

            return Factory.EntityBehaviour.Create(UnitsConfig.ViewPrefab, spawnPosition)
                    .Replace<DebugName, string>(ShortUnitID(config.ID))
                    .Add<Unit, string>(config.ID)
                    .Add<SpriteSortOrder, int>(ViewConfig.SortingOrder.Idle)
                    .Add<Component.Suit, Suit>(config.Suit)

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
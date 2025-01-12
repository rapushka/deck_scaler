using System.Collections.Generic;
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler
{
    public class UnitUtils
    {
        private static IRandom Random => ServiceLocator.Resolve<IRandom>();

        private static UnitsConfig Config => ServiceLocator.Resolve<IConfigs>().Units;

        public Entity<Game> ToAlly(Entity<Game> unit)
            =>
                unit
                    // add components, that makes him the teammate
                    .Is<Draggable>(true)
                    .Is<Teammate>(true)
                    .Is<Fella>(true)
                    .Add<OnSide, Side>(Side.Player)
                    .Bump();

        public IEnumerable<UnitIDRef> GetRandomAllyIDs(int count)
            => GetRandomUnits(count, Config.Allies);

        public IEnumerable<UnitIDRef> GetRandomEnemyIDs(int count)
            => GetRandomUnits(count, Config.Enemies);

        private static IEnumerable<UnitIDRef> GetRandomUnits(int count, IReadOnlyCollection<UnitIDRef> collection)
        {
            for (var i = 0; i < count; i++)
            {
                var randomAllyID = Random.PickRandom(collection);
                yield return randomAllyID;
            }
        }
    }
}
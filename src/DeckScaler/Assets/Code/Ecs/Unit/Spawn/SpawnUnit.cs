using DeckScaler.Component;
using DeckScaler.Service;
using DesperateDevs.Reflection;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<DeckScaler.Model>;

namespace DeckScaler.Systems
{
    public sealed class SpawnUnit : IExecuteSystem
    {
        private readonly IGroup<Entity<Model>> _entities = Contexts.Instance.GetGroup(Get<Component.SpawnUnit>());

        private static Debug Debug => Services.Get<Debug>();

        public void Execute()
        {
            foreach (var e in _entities)
            {
                var (id, side) = e.Get<Component.SpawnUnit>().Value;
                var config = Services.Get<Configs>().Units[id];

                var isLead = config.Type is UnitType.Lead;
                var isOnPlayerSide = side is Side.Player;

                if (isLead)
                    Debug.Assert(isOnPlayerSide);

                // TODO: portrait

                var entity = Contexts.Instance.Get<Model>().CreateEntity()
                                     .Add<Name, string>(config.ID) // TODO: localized names?
                                     .Add<UnitID, string>(config.ID)
                                     .Is<Lead>(isLead)
                                     .Is<Ally>(isOnPlayerSide)
                                     .Add<Component.Suit, Suit>(config.Suit)
                                     .Add<Health, int>(config.Health)
                                     .Add<Stats, StatsData>(config.StatsData);

                Services.Get<EventBus>().Send<UnitSpawned, Entity<Model>>(entity);
            }
        }
    }
}
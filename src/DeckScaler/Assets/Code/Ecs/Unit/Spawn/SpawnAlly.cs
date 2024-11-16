using DeckScaler.Component;
using DeckScaler.Service;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class SpawnAlly : OnEventSystem<Component.SpawnAlly>
    {
        private static IDebug Debug => Services.Get<IDebug>();

        protected override void OnEvent(Component.SpawnAlly @event)
        {
            var unitID = @event.Value;
            var config = Services.Get<Configs>().Units[unitID];

            var isLead = config.Type is UnitType.Lead;

            Debug.Assert(config.Type is not UnitType.Enemy);
            // TODO: portrait

            var entity = Contexts.Instance.Get<Model>().CreateEntity()
                                 .Add<Name, string>(config.ID) // TODO: localized names?
                                 .Add<UnitID, string>(config.ID)
                                 .Is<Lead>(isLead)
                                 .Is<Ally>(true)
                                 .Add<Component.Suit, Suit>(config.Suit)
                                 .Add<Health, int>(config.Health)
                                 .Add<Stats, StatsData>(config.StatsData);

            Services.Get<EventBus>().Send<UnitSpawned, Entity<Model>>(entity);
        }
    }
}
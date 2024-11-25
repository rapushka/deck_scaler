using DeckScaler.Component;
using DeckScaler.Scopes;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class LoadUnitStatViews : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _entities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Loading>()
                    .And<Stats>()
                    .And<Component.StatsView>()
            );

        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var view = entity.Get<Component.StatsView>().Value;
                var stats = entity.Get<Stats>().Value;
                view.Stats = stats;
            }
        }
    }
}
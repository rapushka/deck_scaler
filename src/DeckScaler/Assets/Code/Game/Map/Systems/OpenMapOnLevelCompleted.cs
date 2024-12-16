using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class OpenMapOnLevelCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<LevelCompleted>()
                    .Without<Processed>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var entity in _events)
                entity.Add<OpenMapAfter, Timer>(new(Config.DelayBeforeMapAppear));
        }
    }
}
using System.Collections.Generic;
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
                    .Without<OpenMapAfter>()
                    .Build()
            );
        private readonly List<Entity<Game>> _buffer = new(16);

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var entity in _events.GetEntities(_buffer))
            {
                Progress.MarkLevelAsCompleted();

                var streetIsCompleted = Progress.CurrentLevelIndex >= Config.CountOfLevelOnStreet;
                if (streetIsCompleted)
                    Progress.GoToNextStreet();

                entity
                    .Add<OpenMapAfter, Timer>(new(Config.DelayBeforeMapAppear))
                    .Is<RefreshMap>(streetIsCompleted)
                    ;
            }
        }
    }
}
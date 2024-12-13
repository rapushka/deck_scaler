using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class MarkLevelCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<LevelCompleted>()
                    .Without<Processed>()
                    .Build()
            );

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var _ in _events)
                Progress.MarkLevelAsCompleted();
        }
    }
}
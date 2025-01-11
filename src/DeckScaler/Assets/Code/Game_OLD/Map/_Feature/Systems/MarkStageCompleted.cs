using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public class MarkStageCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        private static Entity<Game> CurrentStageEntity => Contexts.Instance.Get<Game>().Unique.GetEntity<CurrentStage>();

        private static PrimaryEntityIndex<Game, StageIndex, int> Index
            => Contexts.Instance.Get<Game>().GetPrimaryIndex<StageIndex, int>();

        public void Execute()
        {
            foreach (var _ in _events)
            {
                Progress.MarkStageAsCompleted();

                var currentStageEntity = CurrentStageEntity;
                currentStageEntity
                    .Is<CompletedStage>(true)
                    .Is<CurrentStage>(false)
                    ;

                var previousStageIndex = currentStageEntity.Get<StageIndex, int>();
                if (Index.TryGetEntity(previousStageIndex + 1, out var nextStage))
                {
                    nextStage
                        .Is<CurrentStage>(true)
                        ;
                }
            }
        }
    }
}
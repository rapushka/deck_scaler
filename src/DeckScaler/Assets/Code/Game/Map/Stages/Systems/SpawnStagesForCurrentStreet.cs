using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SpawnStagesForCurrentStreet : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _requests
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RequireSpawnStages>()
                    .Build()
            );

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var _ in _requests)
            {
                var currentStage = Progress.CurrentStageIndex;

                for (var stageIndex = 0; stageIndex < Config.CountOfStagesOnStreet; stageIndex++)
                {
                    CreateEntity.Next()
                        .Add<DebugName, string>($"stage: {stageIndex}")
                        .Add<StageIndex, int>(stageIndex)
                        .Is<CurrentStage>(stageIndex == currentStage)
                        .Is<CompletedStage>(stageIndex > currentStage)
                        ;
                }
            }
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public class MarkStreetCompleted : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _events
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<StageCompletedEvent>()
                    .Without<Processed>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        private static ProgressData Progress => ServiceLocator.Resolve<IProgress>().CurrentRun;

        public void Execute()
        {
            foreach (var entity in _events)
            {
                var streetIsCompleted = Progress.CurrentStageIndex >= Config.CountOfStagesOnStreet;
                if (streetIsCompleted)
                {
                    Progress.GoToNextStreet();
                    entity.Add<RefreshMap>();

                    CreateEntity.OneFrame()
                        .Add<RequireSpawnStages>();
                }
            }
        }
    }
}
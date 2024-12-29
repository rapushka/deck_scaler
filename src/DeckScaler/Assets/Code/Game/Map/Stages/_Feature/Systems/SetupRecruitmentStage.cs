using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class SetupRecruitmentStage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<Initializing>()
                    .And<RecruitmentStage>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var stage in _stages)
                stage.Add<RecruitOnStageCount, int>(Config.Recruitment.RecruitCount);
        }
    }
}
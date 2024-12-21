using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler
{
    public sealed class AddRecruitmentStage : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<StageIndex>()
                    .And<Initializing>()
                    .Build()
            );

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Execute()
        {
            foreach (var stage in _stages)
            {
                if (stage.Get<StageIndex, int>() == Config.IndexOfRecruitmentStage)
                    stage.Add<Component.StageType, StageType>(StageType.Recruitment);
            }
        }
    }
}
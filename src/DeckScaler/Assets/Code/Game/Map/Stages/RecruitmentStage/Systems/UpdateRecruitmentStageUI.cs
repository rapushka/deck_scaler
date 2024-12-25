using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;

namespace DeckScaler.Systems
{
    public sealed class UpdateRecruitmentStageUI : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _newStages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<Stage>()
                    .And<SelectStage>()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var stage in _newStages)
            {
                var enableRecruitmentStageUI = stage.Is<RecruitmentStage>();
                HUD.RecruitmentStageView.SetActive(enableRecruitmentStageUI);
            }
        }
    }
}
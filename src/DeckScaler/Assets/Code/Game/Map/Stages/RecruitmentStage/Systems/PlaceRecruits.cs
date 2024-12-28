using DeckScaler.Component;
using DeckScaler.Scopes;
using DeckScaler.Service;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace DeckScaler.Systems
{
    public sealed class PlaceRecruits : IExecuteSystem
    {
        private readonly IGroup<Entity<Game>> _stages
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecruitmentStage>()
                    .And<SelectStage>()
                    .Build()
            );

        private readonly IGroup<Entity<Game>> _recruits
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Game>
                    .With<RecruitmentCandidate>()
                    .Build()
            );

        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Execute()
        {
            foreach (var _ in _stages)
            {
                var unitsRoot = HUD.RecruitmentStageView.UnitsRoot;
                var spacing = HUD.RecruitmentStageView.Spacing;

                var currentX = -spacing * (_recruits.count - 1) / 2f;

                foreach (var recruit in _recruits)
                {
                    var unitPosition = unitsRoot.position.Add(x: currentX);

                    recruit
                        .Add<AnimateMovement>()
                        .Replace<TargetPosition, Vector2>(unitPosition)
                        ;

                    currentX += spacing;
                }
            }
        }
    }
}
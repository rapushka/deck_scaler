using DeckScaler.Component;
using DeckScaler.Systems;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Cursor = DeckScaler.Component.Cursor;
using Input = DeckScaler.Scopes.Input;

namespace DeckScaler
{
    public sealed class RecruitmentStageFeature : Feature
    {
        public RecruitmentStageFeature()
            : base(nameof(RecruitmentStageFeature))
        {
            Add(new HideRecruitmentUIOnInit());

            Add(new SpawnRecruitmentCandidates());
            Add(new PlaceRecruits());
            Add(new DestroyAllRecruitsOnStageCompleted());

            Add(new TEST());

            Add(new UpdateRecruitmentStageUI());
            Add(new HideRecruitmentUIOnStageCompleted());
        }
    }

    public class TEST : IExecuteSystem
    {
        private readonly IGroup<Entity<Input>> _hoveredEntities
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<HoveredEntity>()
                    .Build()
            );
        private readonly IGroup<Entity<Input>> _cursors
            = Contexts.Instance.GetGroup(
                MatcherBuilder<Input>
                    .With<Cursor>()
                    .And<CursorClicked>()
                    .Build()
            );

        public void Execute()
        {
            foreach (var hovered in _hoveredEntities)
            foreach (var _ in _cursors)
            {
                var entity = hovered.Get<HoveredEntity>().Value.GetEntity();

                Debug.Log("click");
                if (entity.Is<RecruitmentCandidate>())
                    Debug.Log("click on recruit!");
            }
        }
    }
}
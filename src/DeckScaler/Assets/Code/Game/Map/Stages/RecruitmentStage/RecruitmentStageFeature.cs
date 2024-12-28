using DeckScaler.Systems;

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

            Add(new UpdateRecruitmentStageUI());
            Add(new HideRecruitmentUIOnStageCompleted());
        }
    }
}
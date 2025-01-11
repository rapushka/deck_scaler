namespace DeckScaler
{
    public sealed class RecruitmentStageFeature : Feature
    {
        public RecruitmentStageFeature()
            : base(nameof(RecruitmentStageFeature))
        {
            Add(new HideRecruitmentUIOnInit());

            Add(new SpawnRecruitmentCandidates());
            Add(new PlaceRecruitsOnRecruitmentStage());
            Add(new DestroyAllRecruitsOnStageCompleted());

            Add(new HandleClickOnRecruit());
            Add(new TakeRecruitToTeam());

            Add(new UpdateRecruitmentStageUI());
            Add(new HideRecruitmentUIOnStageCompleted());
        }
    }
}
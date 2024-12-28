using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class StagesFeature : Feature
    {
        public StagesFeature()
            : base(nameof(StagesFeature))
        {
            Add(new RequireSpawnStagesOnInit());

            Add(new OnRecruitTakenCompleteStage());

            Add(new MarkStageCompleted());
            Add(new MarkStreetCompleted());

            Add(new OnRequireSpawnStagesDestroyOldStages());
            Add(new SpawnStagesForCurrentStreet());

            Add(new AddRecruitmentStage());
            Add(new MakeAllUntypedStagesToFight());
            Add(new AddFlagsForStageType());

            Add(new FightStageFeature());
            Add(new RecruitmentStageFeature());

            Add(new WhenLastStageAndLastStreetCompletedEndRun());
        }
    }
}
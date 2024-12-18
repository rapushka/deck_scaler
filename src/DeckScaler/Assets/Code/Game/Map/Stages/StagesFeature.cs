using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class StagesFeature : Feature
    {
        public StagesFeature()
            : base(nameof(StagesFeature))
        {
            Add(new OnRequireSpawnStagesDestroyOldStages());
            Add(new SpawnStagesForCurrentStreet());

            Add(new MakeAllUntypedStagesToFight());

            Add(new MarkStagesProcessed());

            Add(new MarkStageCompleted());
            Add(new MarkStreetCompleted());

            Add(new WhenLastStageAndLastStreetCompletedEndRun());
        }
    }
}
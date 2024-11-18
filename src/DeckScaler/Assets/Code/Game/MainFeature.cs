using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class MainFeature : Feature
    {
        public MainFeature()
            : base(nameof(MainFeature))
        {
            Add(new SpawnRandomEnemy());

            Add(new PutNewUnitInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());

            Add(new LoadViewsForEntities());
            Add(new LoadUnitPortrait());
            Add(new LoadCardBackgroundsPortrait());
            Add(new LoadUnitStatViews());

            Add(new MarkLoaded());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsFeature : Feature
    {
        public TeamSlotsFeature()
            : base(nameof(TeamSlotsFeature))
        {
            Add(new PutNewTeammateInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());

            Add(new PutNewEnemyInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsFeature : Feature
    {
        public TeamSlotsFeature()
            : base(nameof(TeamSlotsFeature))
        {
            Add(new TeamSlotsViewFeature());

            Add(new PutNewTeammateInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());

            // SpawnTeamSlotForQueuedUnits is called for two times on purpose
            Add(new PutNewEnemyInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());
        }
    }
}
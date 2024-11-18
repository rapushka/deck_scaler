using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsFeature : Feature
    {
        public TeamSlotsFeature()
            : base(nameof(TeamSlotsFeature))
        {
            Add(new PutNewUnitInFirstAvailableSlot());
            Add(new SpawnTeamSlotForQueuedUnits());
        }
    }
}
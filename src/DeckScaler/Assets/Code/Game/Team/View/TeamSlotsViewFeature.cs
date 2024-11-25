using DeckScaler.Systems;
using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new SendEventOnAddedOrRemoved<TeamSlot, Component.ArrangeTeamSlots>());

            Add(new SetupTeamSlotToTeamContainer());
            Add(new SetupTeamSlotChildren());

            Add(new Systems.ArrangeTeamSlots());
        }
    }
}
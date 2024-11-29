using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new SendEventOnAddedOrRemoved<TeamSlot, Component.ArrangeTeamSlots>());

            Add(new SetupTeamSlotToTeamRoot());
            Add(new SetupTeamSlotChildren());

            Add(new Systems.ArrangeTeamSlots());
        }
    }
}
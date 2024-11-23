using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new RequestArrangeTeamSlotsOnNewSlotCreated());

            Add(new SetupTeamSlotToTeamContainer());
            Add(new SetupTeamSlotChildren());

            Add(new ArrangeTeamSlots());
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new PlaceUnitsInTeamSlot());

            Add(new ArrangeTeamSlots());
        }
    }
}
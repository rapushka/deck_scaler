using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new ArrangeTeamSlots());
            Add(new SetTeamSlotsAnimateMovement());

            Add(new PlayUnitAppearAnimation());
            Add(new PlaceSittingUnitsInTeamSlot());

            Add(new AddStrechyDurationDelayOnTeamSlotsScroll());
        }
    }
}
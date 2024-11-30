using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TeamSlotsViewFeature : Feature
    {
        public TeamSlotsViewFeature()
            : base(nameof(TeamSlotsViewFeature))
        {
            Add(new PlayUnitAppearAnimation());
            Add(new PlaceSittingUnitsInTeamSlot());

            Add(new ArrangeTeamSlotsAnimated());
            Add(new SetTeamSlotsAnimateMovement());

            Add(new AddStrechyDurationDelayOnTeamSlotsScroll());
        }
    }
}
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

            Add(new AppearUnitToSlotAnimated());
            Add(new ReturnUnitToSlotAnimated());
            Add(new SetSittingUnitPositionInTeamSlot());

            Add(new AddStrechyDurationDelayOnTeamSlotsScroll());
        }
    }
}
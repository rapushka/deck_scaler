using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FillFreedTeamSlotsFeature : Feature
    {
        public FillFreedTeamSlotsFeature()
            : base(nameof(FillFreedTeamSlotsFeature))
        {
            Add(new MarkEmptySlotAsFreed());

            Add(new MoveNeighborsFromRightToCompletelyEmptySlots());

            Add(new DestroyCompletelyFreedSlots());
        }
    }
}
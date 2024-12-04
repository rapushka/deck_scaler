using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FillFreedTeamSlotsFeature : Feature
    {
        public FillFreedTeamSlotsFeature()
            : base(nameof(FillFreedTeamSlotsFeature))
        {
            Add(new OnUnitDeathCalculateSlotsToMove());

            Add(new OnPlayerPrepareStepPrepareUnitsToMove());
            Add(new OnPlayerPrepareStepMoveUnitsToFillGaps());
        }
    }
}
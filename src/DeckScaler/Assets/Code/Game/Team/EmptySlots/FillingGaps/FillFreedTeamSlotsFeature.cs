using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FillFreedTeamSlotsFeature : Feature
    {
        public FillFreedTeamSlotsFeature()
            : base(nameof(FillFreedTeamSlotsFeature))
        {
            Add(new OnUnitDeathSendFillGapRequests());

            Add(new OnPlayerPrepareStepStartFillGapsTimer());

            Add(new AfterFillGapsDelayElapsedMoveUnits());
            Add(new AfterFillGapsDelayElapsedDestroyRequest());
        }
    }
}
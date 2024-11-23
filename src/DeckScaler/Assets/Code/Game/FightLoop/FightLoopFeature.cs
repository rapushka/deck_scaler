using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FightLoopFeature : Feature
    {
        public FightLoopFeature()
            : base(nameof(FightLoopFeature))
        {
            Add(new StartWithPlayerPrepareStep());

            Add(new RequestEndPlayerPrepareStep());
            Add(new ChangeFightStateOnRequest());

            Add(new OnPlayerAttackStepTeammatesAttackOpponents());
            Add(new EnemyAttackFeature());

            Add(new OnAttackStepStartedStartWaitingForAttackAnimations());
            Add(new WaitForUnitAnimations());
            Add(new EndAttackStateOnAllUnitAnimationsComplete());

            Add(new StartAttackTimer());
            Add(new SendDealDamageOnAttackPrepareTimerElapsed());

            Add(new CleanupElapsedPrepareAttackTimer());
        }
    }
}
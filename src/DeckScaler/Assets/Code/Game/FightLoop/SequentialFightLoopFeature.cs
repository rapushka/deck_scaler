using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class SequentialFightLoopFeature : Feature
    {
        public SequentialFightLoopFeature()
            : base(nameof(SequentialFightLoopFeature))
        {
            Add(new StartWithPlayerPrepareStep());

            Add(new BlockFightStateChangeIfAnyAttackPreparing());
            Add(new BlockFightStateChangeIfAnimationPlaying());

            Add(new ReactOnRequestEndPlayerPrepareStep());
            Add(new ChangeFightStateOnRequest());

            Add(new OnPlayerAttackStepTeammatesAttackOpponents());
            Add(new OnEnemyAttackStepStartedEnemiesAttack());

            Add(new OnAttackStepStartedStartWaitingForAttackAnimations());
            Add(new WaitForUnitAnimations());
            Add(new EndAttackStateOnAllUnitAnimationsComplete());

            Add(new StartAttackTimer());
            Add(new SendDealDamageOnAttackPrepareTimerElapsed());

            Add(new CleanupElapsedPrepareAttackTimer());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AttackFeature : Feature
    {
        public AttackFeature()
            : base(nameof(AnimationFeature))
        {
            Add(new OnPlayerAttackStepTeammatesAttackOpponents());
            Add(new OnEnemyAttackStepStartedEnemiesAttack());

            Add(new StartAttackTimer());
            Add(new SendDealDamageOnAttackPrepareTimerElapsed());

            Add(new CleanupElapsedPrepareAttackTimer());
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AttackFeature : Feature
    {
        public AttackFeature()
            : base(nameof(AnimationFeature))
        {
            Add(new OnAttackStepStartedStartAttackTimer<PlayerAttackStepStarted, HeldTeammate>());
            Add(new OnAttackStepStartedStartAttackTimer<EnemyAttackStepStarted, HeldEnemy>());

            Add(new OnTimerBeforeAttackElapsedThenAttackOpponent());

            Add(new StartAttackTimer());
            Add(new SendDealDamageOnAttackPrepareTimerElapsed());

            Add(new CleanupElapsedPrepareAttackTimer());
        }
    }
}
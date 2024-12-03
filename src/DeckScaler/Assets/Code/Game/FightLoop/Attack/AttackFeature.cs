using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AttackFeature : Feature
    {
        public AttackFeature()
            : base(nameof(AttackFeature))
        {
            // Add(new OnAttackStepStartedStartAttackTimer<PlayerAttackStepStarted, HeldTeammate>());
            // Add(new OnAttackStepStartedStartAttackTimer<EnemyAttackStepStarted, HeldEnemy>());

            Add(new OpponentsFeature());
            Add(new OnTimerBeforeAttackElapsedThenAttackOpponent());

            Add(new StartAttackTimer());
            Add(new SendDealDamageAfterAttackPrepared());

            Add(new OnPrepareAttackTimerElapsed());
            Add(new CleanupElapsedTimers<PrepareAttackTimer>());
        }
    }
}
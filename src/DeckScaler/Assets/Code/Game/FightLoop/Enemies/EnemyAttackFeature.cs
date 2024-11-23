using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class EnemyAttackFeature : Feature
    {
        public EnemyAttackFeature()
            : base(nameof(EnemyAttackFeature))
        {
            Add(new OnEnemyAttackStepStartedEnemiesAttack());
        }
    }
}
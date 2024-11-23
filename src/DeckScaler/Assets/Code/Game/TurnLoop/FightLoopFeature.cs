using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class FightLoopFeature : Feature
    {
        public FightLoopFeature()
            : base(nameof(FightLoopFeature))
        {
            Add(new OnEndTurnAllTeammatesAttackOpponents());

            Add(new EnemyAttackFeature());

            Add(new SendDealDamageWithAttack());

            Add(new CleanupAttackers());
        }
    }
}
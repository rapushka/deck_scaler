using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TurnLoopFeature : Feature
    {
        public TurnLoopFeature()
            : base(nameof(TurnLoopFeature))
        {
            Add(new OnEndTurnAllTeammatesAttackOpponents());
            Add(new SendDealDamageWithAttack());

            Add(new SendTurnEndedEventWhenThereNoAttackers());

            Add(new OnTurnEndedWhenNoAttackersStartEnemiesTurn());
            Add(new OnStartEnemyTurnEnemiesAttack());

            Add(new CleanupAttackers());
        }
    }
}
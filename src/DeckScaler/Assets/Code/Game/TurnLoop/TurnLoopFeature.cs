using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TurnLoopFeature : Feature
    {
        public TurnLoopFeature()
            : base(nameof(TurnLoopFeature))
        {
            Add(new OnEndTurnAllTeammatesAttackOpponents());
            Add(new DealDamageWithAttack());
        }
    }
}
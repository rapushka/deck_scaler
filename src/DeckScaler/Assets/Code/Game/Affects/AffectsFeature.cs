using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class AffectsFeature : Feature
    {
        public AffectsFeature()
            : base(nameof(AffectsFeature))
        {
            Add(new HealUnitsOnSideTurnStartedForHearts());

            Add(new StealMoneyFromOpponentForDiamonds());
            Add(new StealMoneyFeature());

            Add(new DamageFeature());
        }
    }
}
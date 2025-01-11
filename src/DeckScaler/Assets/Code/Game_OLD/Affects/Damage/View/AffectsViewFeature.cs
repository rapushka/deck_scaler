using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class AffectsViewFeature : Feature
    {
        public AffectsViewFeature()
            : base(nameof(AffectsViewFeature))
        {
            Add(new OnUnitDealDamagePlayNumbersView());
            Add(new OnUnitHealPlayNumbersView());
            Add(new OnUnitStealMoneyPlayNumbersView());
        }
    }
}
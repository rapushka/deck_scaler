using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class DamageViewFeature : Feature
    {
        public DamageViewFeature()
            : base(nameof(DamageViewFeature))
        {
            Add(new OnUnitDealDamagePlayNumbersView());
        }
    }
}
namespace DeckScaler.Component
{
    public sealed class AffectsFeature : Feature
    {
        public AffectsFeature()
            : base(nameof(AffectsFeature))
        {
            Add(new HealFeature());
            Add(new StealMoneyFeature());
            Add(new DamageFeature());
        }
    }
}
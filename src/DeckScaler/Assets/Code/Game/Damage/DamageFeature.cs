namespace DeckScaler
{
    public sealed class DamageFeature : Feature
    {
        public DamageFeature()
            : base(nameof(DamageFeature))
        {
            Add(new Systems.DealDamage());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class DamageFeature : Feature
    {
        public DamageFeature()
            : base(nameof(DamageFeature))
        {
            Add(new IncreaseOutcomeDamageForSpades());
            Add(new DecreaseIncomeDamageForClubs());

            Add(new ApplyDealDamageAffect());
        }
    }
}
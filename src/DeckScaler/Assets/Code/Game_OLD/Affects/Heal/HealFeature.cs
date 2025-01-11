namespace DeckScaler
{
    public sealed class HealFeature : Feature
    {
        public HealFeature()
            : base(nameof(HealFeature))
        {
            Add(new HealUnitsOnSideTurnStartedForHearts());

            Add(new ApplyHealAffect());
        }
    }
}
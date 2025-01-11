using DeckScaler.Component;

namespace DeckScaler
{
    public sealed class AffectsFeature : Feature
    {
        public AffectsFeature()
            : base(nameof(AffectsFeature))
        {
            Add(new OnTurnStartedNotifyUnits());
            Add(new OnTurnStartedTimerElapsedTriggerAbility());

            Add(new HealFeature());
            Add(new StealMoneyFeature());
            Add(new DamageFeature());

            Add(new AffectsViewFeature());

            Add(new RemoveComponent<TriggerOnTurnStartedAbility>());
        }
    }
}
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class OnTurnStartedReactionsFeature : Feature
    {
        public OnTurnStartedReactionsFeature()
            : base(nameof(OnTurnStartedReactionsFeature))
        {
            Add(new HealUnitsOnSideTurnStartedForHearts());
            Add(new StealMoneyFromOpponentForDiamonds());

            Add(new StealMoneyFeature());
        }
    }
}
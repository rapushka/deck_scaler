using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class StealMoneyFeature : Feature
    {
        public StealMoneyFeature()
            : base(nameof(StealMoneyFeature))
        {
            Add(new StealMoney());
        }
    }
}
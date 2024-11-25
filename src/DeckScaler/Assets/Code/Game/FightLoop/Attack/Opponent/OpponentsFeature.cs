using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class OpponentsFeature : Feature
    {
        public OpponentsFeature()
            : base(nameof(OpponentsFeature))
        {
            Add(new ResetOpponent());
            Add(new UpdateOpponentStraightforward());
        }
    }
}
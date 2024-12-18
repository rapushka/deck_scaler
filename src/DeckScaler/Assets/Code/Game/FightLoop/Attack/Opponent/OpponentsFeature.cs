using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class OpponentsFeature : Feature
    {
        public OpponentsFeature()
            : base(nameof(OpponentsFeature))
        {
            Add(new SendEventOnAddedOrRemoved<Component.Unit, Component.RecalculateOpponents>());
            Add(new SendRecalculateOpponentsOnUnitDropped());

            Add(new ResetOpponent());
            Add(new UpdateOpponentStraightforward());
            Add(new SeekForNeighborOpponents());
        }
    }
}
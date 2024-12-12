using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class TrinketsFeature : Feature
    {
        public TrinketsFeature()
        {
            Add(new SpawnTrinketSlotsFromProgress());
            Add(new SpawnTrinketsFromProgress());

            Add(new PlaceTrinketInSlot());

            Add(new ArrangeTrinketSlotPositions());
            Add(new ArrangeTrinketPositionToSlot());
        }
    }
}
namespace DeckScaler
{
    public sealed class TrinketsFeature : Feature
    {
        public TrinketsFeature()
        {
            Add(new SpawnTrinketsFromProgress());
        }
    }
}
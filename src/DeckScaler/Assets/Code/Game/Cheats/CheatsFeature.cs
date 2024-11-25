using DeckScaler.Cheats.Systems;

namespace DeckScaler.Cheats
{
    public sealed class CheatsFeature : Feature
    {
        public CheatsFeature()
            : base(nameof(CheatsFeature))
        {
            Add(new SpawnUnitCheat());

            Add(new LogUnprocessedCheats());
            Add(new DestroyAllCheats());
        }
    }
}
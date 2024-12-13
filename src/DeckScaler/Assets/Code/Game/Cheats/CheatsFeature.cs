using DeckScaler.Cheats.Systems;

namespace DeckScaler.Cheats
{
    public sealed class CheatsFeature : Feature
    {
        public CheatsFeature()
            : base(nameof(CheatsFeature))
        {
            Add(new SpawnUnitFeature());
            Add(new GameOverFeature());

            Add(new TMP_SetMaxPowerCheat());

            Add(new LogUnprocessedCheats());
            Add(new DestroyAllCheats());
        }
    }
}
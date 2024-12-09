using DeckScaler.Cheats.Systems;

namespace DeckScaler.Cheats
{
    public sealed class CheatsFeature : Feature
    {
        public CheatsFeature()
            : base(nameof(CheatsFeature))
        {
            Add(new ParseSpawnAsTeammateCheat());
            Add(new ParseSpawnAsEnemyCheat());

            Add(new ProcessSpawnUnitCheat());

            Add(new LogUnprocessedCheats());
            Add(new DestroyAllCheats());
        }
    }
}
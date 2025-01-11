using DeckScaler.Cheats.Systems;

namespace DeckScaler.Cheats
{
    public sealed class SpawnUnitFeature : Feature
    {
        public SpawnUnitFeature()
            : base(nameof(SpawnUnitFeature))
        {
            Add(new ParseSpawnAsTeammateCheat());
            Add(new ParseSpawnAsEnemyCheat());

            Add(new ProcessSpawnUnitCheat());
        }
    }
}
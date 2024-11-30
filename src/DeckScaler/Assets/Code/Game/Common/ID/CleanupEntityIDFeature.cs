using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class CleanupEntityIDFeature : Feature
    {
        public CleanupEntityIDFeature()
            : base(nameof(CleanupEntityIDFeature))
        {
            Add(new CleanupMissingEntityID<HeldTeammate>());
            Add(new CleanupMissingEntityID<HeldEnemy>());
        }
    }
}
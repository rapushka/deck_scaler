using DeckScaler.Component;
using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class EntityIDFeature : Feature
    {
        public EntityIDFeature()
            : base(nameof(EntityIDFeature))
        {
            Add(new CleanupMissingEntityID<HeldTeammate>());
            Add(new CleanupMissingEntityID<HeldEnemy>());
        }
    }
}
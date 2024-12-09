using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class PlayerInventoryFeature : Feature
    {
        public PlayerInventoryFeature()
            : base(nameof(PlayerInventoryFeature))
        {
            Add(new LoadPlayerInventoryFromProgress());
        }
    }
}
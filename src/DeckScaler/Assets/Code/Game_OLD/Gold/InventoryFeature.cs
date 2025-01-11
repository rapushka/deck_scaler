using DeckScaler.Systems;

namespace DeckScaler.Component
{
    public sealed class InventoryFeature : Feature
    {
        public InventoryFeature()
            : base(nameof(InventoryFeature))
        {
            Add(new LoadPlayerInventoryFromProgress());
            Add(new CreateEnemyInventory());
        }
    }
}
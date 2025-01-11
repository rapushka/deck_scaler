namespace DeckScaler
{
    public sealed class ShopItemsAvailabilityFeature : Feature
    {
        public ShopItemsAvailabilityFeature()
            : base(nameof(ShopItemsAvailabilityFeature))
        {
            Add(new RequestUpdateShopOnShopEnter());
            Add(new RequestUpdateShopOnItemBought());

            Add(new UpdateShopItems());
        }
    }
}
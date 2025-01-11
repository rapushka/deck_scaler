namespace DeckScaler
{
    public sealed class ShopRerollFeature : Feature
    {
        public ShopRerollFeature()
            : base(nameof(ShopRerollFeature))
        {
            Add(new InitializeRerollItemInShop());
            Add(new RestockShopOnReroll());
        }
    }
}
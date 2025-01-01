using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class ShopStageFeature : Feature
    {
        public ShopStageFeature()
            : base(nameof(ShopStageFeature))
        {
            Add(new HideShopUIOnInit());

            Add(new SpawnUnitsInShop());
            Add(new PlaceUnitsInShop());

            Add(new SpawnTrinketsInShop());
            Add(new DestroyAllShopItemsOnStageCompleted());

            Add(new TryBuyOnUnitInShopClicked());
            Add(new TryProcessPurchase());
            Add(new AddBoughtUnitFromShopToTeam());

            Add(new UpdateShopStageUI());
            Add(new HideShopUIOnStageCompleted());
        }
    }
}
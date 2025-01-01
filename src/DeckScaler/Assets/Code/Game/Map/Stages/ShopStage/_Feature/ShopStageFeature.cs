using DeckScaler.Component;
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
            Add(new PlaceTrinketsInShop());

            Add(new DestroyAllShopItemsOnStageCompleted());

            Add(new BuyOnShopItemClicked());

            Add(new CheckEmptySlotsForTrinkets());
            Add(new TrySpendMoneyToBuy());

            Add(new AddBoughtUnitFromShopToTeam());
            Add(new AddBoughtTrinketFromShopToInventory());

            Add(new UpdateShopStageUI());
            Add(new HideShopUIOnStageCompleted());

            Add(new RemoveComponent<TryBuy>());
            Add(new RemoveComponent<Bought>());
            Add(new RemoveComponent<NotEnoughMoney>());
        }
    }
}
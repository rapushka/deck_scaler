using DeckScaler.Systems;

namespace DeckScaler
{
    public sealed class ShopStageFeature : Feature
    {
        public ShopStageFeature()
            : base(nameof(ShopStageFeature))
        {
            Add(new HideShopUIOnInit());

            Add(new UpdateShopStageUI());
            Add(new HideShopUIOnStageCompleted());
        }
    }
}
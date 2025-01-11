using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public sealed class HideShopUIOnInit : IInitializeSystem
    {
        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Initialize()
        {
            HUD.ShopStageView.SetActive(false);
        }
    }
}
using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
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
using DeckScaler.Service;
using Entitas;

namespace DeckScaler.Systems
{
    public class InitializeAndShowMapOnStartOfRun : IInitializeSystem
    {
        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        public void Initialize()
        {
            HUD.MapView.LoadLevelsOnCurrentStreet();
            HUD.MapView.Show();
        }
    }
}
using DeckScaler.Component;
using DeckScaler.Service;
using Entitas;

namespace DeckScaler
{
    public class InitializeAndShowMapOnStartOfRun : IInitializeSystem
    {
        private static GameplayHUD HUD => ServiceLocator.Resolve<IUiMediator>().GetCurrentScreen<GameplayHUD>();

        private static MapConfig Config => ServiceLocator.Resolve<IConfigs>().Map;

        public void Initialize()
        {
            HUD.MapView.Hide();

            CreateEntity.Empty()
                .Add<OpenMapAfter, Timer>(new(Config.DelayBeforeMapAppear))
                .Add<RefreshMap>()
                ;
        }
    }
}
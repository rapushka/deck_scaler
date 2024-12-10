using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<ICameras>().SpawnCameras();

            ServiceLocator.Resolve<IUiMediator>().InitializeUI();
            ServiceLocator.Resolve<IEcs>().Initialize();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
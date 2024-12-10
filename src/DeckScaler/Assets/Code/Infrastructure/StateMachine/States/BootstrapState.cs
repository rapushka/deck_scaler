using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<ICameras>().SpawnCameras();

            ServiceLocator.Resolve<IUI>().Init();
            ServiceLocator.Resolve<IEcs>().Init();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<IUI>().Init();
            ServiceLocator.Resolve<IEcs>().Init();

            ServiceLocator.Resolve<ICameras>().SpawnCameras();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
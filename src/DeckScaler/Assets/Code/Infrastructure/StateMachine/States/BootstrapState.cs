using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Get<IUI>().Init();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
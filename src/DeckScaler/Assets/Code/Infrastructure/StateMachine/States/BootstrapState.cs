using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            Services.Get<IUI>().Init();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
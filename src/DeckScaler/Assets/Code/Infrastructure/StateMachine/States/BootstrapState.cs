using DeckScaler.Service;

namespace DeckScaler
{
    public class BootstrapState : GameState
    {
        public override void Enter()
        {
            Services.Get<UI>().Init();

            StateMachine.Enter<MainMenuState>();
        }
    }
}
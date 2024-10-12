using DeckScaler.Service;

namespace DeckScaler.States
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
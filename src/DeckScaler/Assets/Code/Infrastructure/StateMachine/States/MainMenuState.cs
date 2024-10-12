using DeckScaler.Service;

namespace DeckScaler.States
{
    public class MainMenuState : GameState
    {
        public override void Enter()
        {
            Services.Get<UI>().ShowMainMenu();
        }
    }
}
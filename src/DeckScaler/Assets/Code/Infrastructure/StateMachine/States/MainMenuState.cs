using DeckScaler.Service;

namespace DeckScaler
{
    public class MainMenuState : GameState
    {
        public override void Enter()
        {
            Services.Get<IUI>().ShowMainMenu();
        }
    }
}
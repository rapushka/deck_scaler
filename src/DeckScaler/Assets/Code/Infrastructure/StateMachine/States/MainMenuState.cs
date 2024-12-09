using DeckScaler.Service;

namespace DeckScaler
{
    public class MainMenuState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Get<IUI>().ShowMainMenu();
        }
    }
}
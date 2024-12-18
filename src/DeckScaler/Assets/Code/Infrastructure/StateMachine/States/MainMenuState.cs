using DeckScaler.Service;

namespace DeckScaler
{
    public class MainMenuState : GameState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public override void Enter()
        {
            UiMediator.OpenScreen<MainMenu>();
        }
    }
}
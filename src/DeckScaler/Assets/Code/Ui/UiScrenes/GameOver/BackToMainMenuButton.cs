using DeckScaler.Service;

namespace DeckScaler
{
    public class BackToMainMenuButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.BackToMainMenu();
        }
    }
}
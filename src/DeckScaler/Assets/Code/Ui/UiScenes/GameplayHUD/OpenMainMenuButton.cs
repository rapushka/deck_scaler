namespace DeckScaler.Ui.Views.GameplayHUD
{
    public class OpenMainMenuButton : BaseButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolve<IGameStateMachine>().Enter<MainMenuState>();
        }
    }
}
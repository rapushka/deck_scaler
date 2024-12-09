namespace DeckScaler.Ui.Views.GameplayHUD
{
    public class OpenMainMenuButton : BaseButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Get<IGameStateMachine>().Enter<MainMenuState>();
        }
    }
}
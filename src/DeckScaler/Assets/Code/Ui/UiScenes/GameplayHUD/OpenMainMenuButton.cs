namespace DeckScaler.Ui.Views.GameplayHUD
{
    public class OpenMainMenuButton : BaseButton
    {
        protected override void OnClick()
        {
            Services.Get<IGameStateMachine>().Enter<MainMenuState>();
        }
    }
}
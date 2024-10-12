using DeckScaler;
using DeckScaler.States;

namespace Code.Ui.Views.GameplayHUD
{
    public class OpenMainMenuButton : BaseButton
    {
        protected override void OnClick()
        {
            Services.Get<GameStateMachine>().Enter<MainMenuState>();
        }
    }
}
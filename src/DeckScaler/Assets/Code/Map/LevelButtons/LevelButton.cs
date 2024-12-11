using DeckScaler.Service;

namespace DeckScaler
{
    public class LevelButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        private static GameplayHUD HUD => UiMediator.GetCurrentScreen<GameplayHUD>();

        protected override void OnClick()
        {
            HUD.MapView.SelectNextLevel();
        }
    }
}
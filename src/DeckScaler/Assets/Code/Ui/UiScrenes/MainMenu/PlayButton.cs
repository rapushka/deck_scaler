using DeckScaler.Service;

namespace DeckScaler
{
    public class PlayButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.StartNewRun();
        }
    }
}
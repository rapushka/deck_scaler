using DeckScaler.Service;

namespace DeckScaler
{
    public class LeaveGameplayButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.EndRun();
        }
    }
}
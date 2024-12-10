using DeckScaler.Service;

namespace DeckScaler
{
    public class EndTurnButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.EndTurn();
        }
    }
}
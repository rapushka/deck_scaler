using DeckScaler.Service;

namespace DeckScaler
{
    public class EndTurnButton : BaseButton
    {
        private static IUiMediator UiMediator => ServiceLocator.Get<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.EndTurn();
        }
    }
}
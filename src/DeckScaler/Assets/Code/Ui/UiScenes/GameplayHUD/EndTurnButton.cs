using DeckScaler.Service;

namespace DeckScaler
{
    public class EndTurnButton : BaseButton
    {
        private static IUiMediator UiMediator => Services.Get<IUiMediator>();

        protected override void OnClick()
        {
            UiMediator.EndTurn();
        }
    }
}
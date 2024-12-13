using DeckScaler.Service;

namespace DeckScaler
{
    public class GameVictoryState : GameState
    {
        private static IUiMediator UiMediator => ServiceLocator.Resolve<IUiMediator>();

        public override void Enter()
        {
            UiMediator.OpenScreen<GameVictoryScreen>();
        }
    }
}
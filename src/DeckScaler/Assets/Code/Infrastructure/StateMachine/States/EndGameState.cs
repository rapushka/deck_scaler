namespace DeckScaler
{
    public class EndGameState : GameState
    {
        private static IIdentifierServer Identifiers => ServiceLocator.Resolve<IIdentifierServer>();

        public override void Enter()
        {
            Identifiers.Reset();
            StateMachine.Enter<MainMenuState>();
        }
    }
}
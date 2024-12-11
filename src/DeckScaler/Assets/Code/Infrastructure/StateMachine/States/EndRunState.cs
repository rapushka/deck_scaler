namespace DeckScaler
{
    public class EndRunState : GameState
    {
        private static IIdentifierServer Identifiers => ServiceLocator.Resolve<IIdentifierServer>();

        public override void Enter()
        {
            Identifiers.Reset();
            StateMachine.Enter<MainMenuState>();
        }
    }
}
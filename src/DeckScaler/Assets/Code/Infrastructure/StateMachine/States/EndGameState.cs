namespace DeckScaler
{
    public class EndGameState : GameState
    {
        public override void Enter()
        {
            StateMachine.Enter<MainMenuState>();
        }
    }
}
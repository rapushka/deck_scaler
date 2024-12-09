namespace DeckScaler
{
    public class LoadCurrentLevelState : GameState
    {
        public override void Enter()
        {
            StateMachine.Enter<GameplayState>();
        }
    }
}
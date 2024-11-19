namespace DeckScaler
{
    public class LoadCurrentStageState : GameState
    {
        public override void Enter()
        {
            StateMachine.Enter<GameplayState>();
        }
    }
}
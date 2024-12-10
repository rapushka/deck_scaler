using DeckScaler.Service;

namespace DeckScaler
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<IProgress>().StartNewRun();

            StateMachine.Enter<LoadCurrentLevelState>();
        }
    }
}
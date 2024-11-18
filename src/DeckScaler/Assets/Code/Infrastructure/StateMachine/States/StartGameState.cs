using DeckScaler.Service;

namespace DeckScaler
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Get<IEcs>().Init();

            Services.Get<IProgress>().StartNewRun();

            StateMachine.Enter<LoadCurrentStageState>();
        }
    }
}
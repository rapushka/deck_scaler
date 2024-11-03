using DeckScaler.Service;

namespace DeckScaler.States
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Get<Ecs>().Init();

            Services.Get<Progress>().StartNewRun();

            StateMachine.Enter<LoadCurrentStageState>();
        }
    }
}
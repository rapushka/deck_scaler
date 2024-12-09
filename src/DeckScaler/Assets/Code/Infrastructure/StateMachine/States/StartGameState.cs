using DeckScaler.Service;

namespace DeckScaler
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Get<IEcs>().Init();
            ServiceLocator.Get<IIndexesInitializer>().Initialize();

            ServiceLocator.Get<IProgress>().StartNewRun();

            StateMachine.Enter<LoadCurrentStageState>();
        }
    }
}
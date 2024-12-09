using DeckScaler.Service;

namespace DeckScaler
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<IEcs>().Init();
            ServiceLocator.Resolve<IIndexesInitializer>().Initialize();

            ServiceLocator.Resolve<IProgress>().StartNewRun();

            StateMachine.Enter<LoadCurrentStageState>();
        }
    }
}
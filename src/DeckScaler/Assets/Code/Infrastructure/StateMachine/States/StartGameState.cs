using DeckScaler.Service;

namespace DeckScaler
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<IEcs>().CreateFeature();

            ServiceLocator.Resolve<IProgress>().StartNewRun();

            StateMachine.Enter<LoadCurrentLevelState>();
        }
    }
}
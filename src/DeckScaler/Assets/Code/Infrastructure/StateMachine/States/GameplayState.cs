using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Resolve<IUI>().ShowGameplayHUD();
        }

        public override void Exit()
        {
            ServiceLocator.Resolve<IEcs>().Dispose();
        }
    }
}
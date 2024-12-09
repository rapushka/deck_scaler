using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            ServiceLocator.Get<IUI>().ShowGameplayHUD();
        }

        public override void Exit()
        {
            ServiceLocator.Get<IEcs>().Dispose();
        }
    }
}
using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            Services.Get<IUI>().ShowGameplayHUD();
        }

        public override void Exit()
        {
            Services.Get<IEcs>().Dispose();
        }
    }
}
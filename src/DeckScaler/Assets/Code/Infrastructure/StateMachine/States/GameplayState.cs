using DeckScaler.Service;

namespace DeckScaler
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            Services.Get<UI>().ShowGameplayHUD();
        }

        public override void Exit()
        {
            Services.Get<Ecs>().Dispose();
        }
    }
}
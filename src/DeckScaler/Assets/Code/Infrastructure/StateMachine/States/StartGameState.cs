using DeckScaler.Service;

namespace DeckScaler.States
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Get<Ecs>().Init();
            
            // TODO: wait 1 frame or what?

            Services.Get<UI>().ShowGameplayHUD();
            StateMachine.Enter<GameplayState>();
        }
    }
}
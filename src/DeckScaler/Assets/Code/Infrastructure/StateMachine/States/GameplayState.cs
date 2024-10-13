using DeckScaler.Service;

namespace DeckScaler.States
{
    public class GameplayState : GameState
    {
        public override void Enter() { }

        public override void Exit()
        {
            Services.Get<Ecs>().Dispose();
        }
    }
}
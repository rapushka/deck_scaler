namespace DeckScaler.States
{
    public class GameplayState : GameState
    {
        public override void Enter() { }

        public override void Exit()
        {
            Services.Instance.Ecs.Dispose();
        }
    }
}
namespace DeckScaler.States
{
    public class StartGameState : GameState
    {
        public override void Enter()
        {
            Services.Instance.Ecs.Init();

            Services.Instance.UI.ShowGameplayHUD();
            StateMachine.Enter<GameplayState>();
        }
    }
}
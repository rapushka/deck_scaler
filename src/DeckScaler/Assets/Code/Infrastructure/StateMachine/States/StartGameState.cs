namespace DeckScaler.States
{
	public class StartGameState : GameState
	{
		public override void Enter()
		{
			Services.Instance.UI.ShowGameplayHUD();

			StateMachine.Enter<GameplayState>();
		}
	}
}
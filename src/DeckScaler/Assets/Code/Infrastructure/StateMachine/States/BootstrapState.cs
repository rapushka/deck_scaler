namespace DeckScaler.States
{
	public class BootstrapState : GameState
	{
		public override void Enter()
		{
			Services.Instance.UI.Init();

			StateMachine.Enter<MainMenuState>();
		}
	}
}
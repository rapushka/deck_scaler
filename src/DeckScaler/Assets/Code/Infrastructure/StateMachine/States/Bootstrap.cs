namespace DeckScaler.State
{
	public class Bootstrap : BaseState
	{
		public override void Enter()
		{
			Services.Instance.UI.Init();

			StateMachine.Enter<MainMenu>();
		}
	}
}
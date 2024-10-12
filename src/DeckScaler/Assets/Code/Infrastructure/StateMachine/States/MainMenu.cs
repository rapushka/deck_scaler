namespace DeckScaler.State
{
	public class MainMenu : BaseState
	{
		public override void Enter()
		{
			Services.Instance.UI.OpenMainMenu();
		}
	}
}
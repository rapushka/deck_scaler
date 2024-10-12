namespace DeckScaler.States
{
	public class MainMenuState : GameState
	{
		public override void Enter()
		{
			Services.Instance.UI.ShowMainMenu();
		}
	}
}
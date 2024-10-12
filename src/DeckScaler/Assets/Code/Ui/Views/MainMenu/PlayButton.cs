using DeckScaler.States;

namespace DeckScaler
{
	public class PlayButton : BaseButton
	{
		protected override void OnClick()
		{
			Services.Instance.StateMachine.Enter<StartGameState>();
		}
	}
}
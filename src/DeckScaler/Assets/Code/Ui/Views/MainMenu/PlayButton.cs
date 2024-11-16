using DeckScaler;

namespace DeckScaler
{
    public class PlayButton : BaseButton
    {
        protected override void OnClick()
        {
            Services.Get<GameStateMachine>().Enter<StartGameState>();
        }
    }
}
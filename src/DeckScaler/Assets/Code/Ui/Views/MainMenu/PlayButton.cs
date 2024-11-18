namespace DeckScaler
{
    public class PlayButton : BaseButton
    {
        protected override void OnClick()
        {
            Services.Get<IGameStateMachine>().Enter<StartGameState>();
        }
    }
}
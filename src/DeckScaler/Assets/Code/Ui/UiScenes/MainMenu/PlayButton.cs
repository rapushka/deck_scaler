namespace DeckScaler
{
    public class PlayButton : BaseButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Get<IGameStateMachine>().Enter<StartGameState>();
        }
    }
}
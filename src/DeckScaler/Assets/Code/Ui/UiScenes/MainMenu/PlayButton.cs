namespace DeckScaler
{
    public class PlayButton : BaseButton
    {
        protected override void OnClick()
        {
            ServiceLocator.Resolve<IGameStateMachine>().Enter<StartGameState>();
        }
    }
}
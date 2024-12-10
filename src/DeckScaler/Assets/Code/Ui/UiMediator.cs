namespace DeckScaler.Service
{
    public interface IUiMediator : IService
    {
        void InitializeUI();

        void    OpenScreen<TScreen>() where TScreen : BaseUiScreen;
        TScreen GetCurrentScreen<TScreen>() where TScreen : BaseUiScreen;

        void StartNewRun();
        void EndTurn();
        void EndRun();

        void SendCheat(string cheat);
    }

    public class UiMediator : IUiMediator
    {
        private static IUiScreens Screens => ServiceLocator.Resolve<IUiScreens>();

        private static IGameStateMachine StateMachine => ServiceLocator.Resolve<IGameStateMachine>();

        public void InitializeUI()
        {
            Screens.Init();
        }

        public void    OpenScreen<TScreen>() where TScreen : BaseUiScreen       => Screens.Open<TScreen>();
        public TScreen GetCurrentScreen<TScreen>() where TScreen : BaseUiScreen => Screens.GetCurrent<TScreen>();

        public void StartNewRun() => StateMachine.Enter<StartGameState>();
        public void EndTurn()     => CreateEntity.OneFrame().Add<Component.RequestEndTurn>();
        public void EndRun()      => StateMachine.Enter<EndGameState>();

        public void SendCheat(string cheat) => CreateEntity.Cheat(cheat);
    }
}
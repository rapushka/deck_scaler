using DeckScaler.Service;

namespace DeckScaler
{
    public class GameRunner
    {
        private readonly IConfigs _configs;

        public GameRunner(IConfigs configs)
            => _configs = configs;

        public void SetupServices()
        {
            // ReSharper disable RedundantTypeArgumentsOfMethod - I wanna keep consistency here

            ServiceLocator.Register<IConfigs>(_configs);
            ServiceLocator.Register<IUiScreens>(new UiScreens());
            ServiceLocator.Register<ICameras>(_configs.Cameras);
            ServiceLocator.Register<IGameStateMachine>(new GameStateMachine());
            ServiceLocator.Register<IEcs>(new Ecs());
            ServiceLocator.Register<IProgress>(new Progress());
            ServiceLocator.Register<IFactories>(new Factories());
            ServiceLocator.Register<IRandom>(new SimpleRandom());
            ServiceLocator.Register<IUiMediator>(new UiMediator());
            ServiceLocator.Register<ITime>(new SimpleTime());
            ServiceLocator.Register<IInput>(new UnityInput());
            ServiceLocator.Register<IUtils>(new Utils());

            SetupDebugServices();
        }

        public void StartGame()
        {
            var gameStateMachine = ServiceLocator.Resolve<IGameStateMachine>();
            gameStateMachine.Enter<BootstrapState>();
        }

        private void SetupDebugServices()
        {
#if DEBUG
            ServiceLocator.Register<IDebug>(new SimpleDebug());
#else
            ServiceLocator.Register<IDebug>(new DebugMock());
#endif
        }
    }
}
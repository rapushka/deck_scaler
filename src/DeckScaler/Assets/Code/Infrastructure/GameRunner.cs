using DeckScaler.Service;

namespace DeckScaler
{
    public class GameRunner
    {
        private readonly ServicesData _servicesData;

        public GameRunner(ServicesData servicesData)
            => _servicesData = servicesData;

        public void SetupServices()
        {
            ServiceLocator.Register<IUI>(new UI());
            ServiceLocator.Register<ICameras>(new Cameras(_servicesData));
            ServiceLocator.Register<IGameStateMachine>(new GameStateMachine());
            ServiceLocator.Register<IEcs>(new Ecs());
            ServiceLocator.Register<IConfigs>(_servicesData.Configs);
            ServiceLocator.Register<IProgress>(new Progress());
            ServiceLocator.Register<IFactories>(new Factories());
            ServiceLocator.Register<IRandom>(new SimpleRandom());
            ServiceLocator.Register<IUiMediator>(new UiMediator());
            ServiceLocator.Register<ITime>(new SimpleTime());
            ServiceLocator.Register<IInput>(new UnityInput());
            ServiceLocator.Register<IUtils>(new Utils());
            ServiceLocator.Register<IIndexesInitializer>(new IndexesInitializer());

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